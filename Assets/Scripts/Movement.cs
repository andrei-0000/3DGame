using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed, speedJump, speedUp;
    public bool turnLeft, turnRight;
    private CharacterController _cc;
    private Rigidbody _rigibody;
    private Animator _anim;
    private bool inLadder;
    private bool inSlide;
    private Transform PlayerTransform;
    public Transform TeleportGoal;
    public Transform PosInicial;
    public GameObject VcameraP1;
    public GameObject VcameraP2;
     [SerializeField]
    private CinemachineVirtualCamera cvc;
    [SerializeField]
    private CinemachineTransposer ct;

    bool godMode = false;


    public void goRight()
    {
        turnRight = true;
    }

    public void goLeft()
    {
        turnLeft = true;
    }


    void Start()
    {

        turnLeft = turnRight = inLadder = inSlide = false;
        _cc = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
        _rigibody = gameObject.GetComponent<Rigidbody>();
       // PlayerTransform = gameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.G)) godMode = !godMode;
        if (Input.GetKeyDown(KeyCode.Alpha0))  SceneManager.LoadScene(0);
        if (Input.GetKeyDown(KeyCode.Alpha1))  SceneManager.LoadScene(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) SceneManager.LoadScene(2);
        else if (Input.GetKeyDown(KeyCode.Alpha3)) SceneManager.LoadScene(3);
        else if (Input.GetKeyDown(KeyCode.Alpha4)) SceneManager.LoadScene(4);
        else if (Input.GetKeyDown(KeyCode.Alpha5)) SceneManager.LoadScene(5);

        if (inSlide)
        {
            _anim.SetBool("Moving", true);
            Vector3 dir = new Vector3(0f, -0.5f, -1f);
            gameObject.transform.position += dir / speedUp  ;
        }
       /*if (!Input.anyKey) 
            _anim.SetBool("Moving", false);*/
        if(!Input.GetKey(KeyCode.P)){
            _anim.SetBool("Moving", false);
        }
        else if(!Input.GetKey(KeyCode.W)){
            _anim.SetBool("Moving", false);
        }

        //moure's amb el click esquerra del mouse
            if(gameObject.layer == 11){

                if (Input.GetKey(KeyCode.P))
                {
                    if (inLadder == true)
                    {
                        _anim.SetBool("Climb", true);
                        gameObject.transform.position += Vector3.up / speedUp;
                    }
                    else
                    {
                        _anim.SetBool("Moving", true);
                        _cc.SimpleMove(new Vector3(0f, 0f, 0f));
                        _cc.Move(transform.forward * speed * Time.deltaTime);
                    }

                }
            }
            else {
                if (gameObject.layer == 12){
                    if (Input.GetKey(KeyCode.W)) {
                        if (inLadder == true)
                        {
                            _anim.SetBool("Climb", true);
                            gameObject.transform.position += Vector3.up / speedUp ;
                        }
                        else
                        {
                            _anim.SetBool("Moving", true);
                            _cc.SimpleMove(new Vector3(0f, 0f, 0f));
                            _cc.Move(transform.forward * speed * Time.deltaTime);
                        }
                    }
                }
            }
            //moure's a la dreta
            if (turnRight)
            {
                transform.Rotate(new Vector3(0, 90f, 0f));
                turnRight = false;
            }

            //si rotem cap a la esquerra
            if (turnLeft)
            {
                transform.Rotate(new Vector3(0, -45f, 0f));
                turnLeft = false;
            }
        Move(movement);
    }

    void Move(Vector3 dir)
    {
        _cc.SimpleMove(dir.normalized * speed);

    }

     public void killpl(){
         if(!godMode){
             SoundManager.PlaySound("hit");
            _anim.SetBool("Die",true);
            StartCoroutine("Teleport");
            gameObject.GetComponentInChildren<ProgressBar>().saveProgress();
            // PlayerTransform.position = TeleportGoal.position;
         }
        
    }

    public void goUp(bool inside)
    {
        if (inside)
        {
            _cc.enabled = false;
            _rigibody.useGravity = false;
            inLadder = !inLadder;

        }
        else
        {
           _anim.SetBool("Climb", false);
            _cc.enabled = true;
            _cc.Move(transform.forward * speed * 4  * Time.deltaTime);
            inLadder = !inLadder;
            _rigibody.useGravity = true;

        }
    }

    public void goSlide(bool inside)
    {
        VcameraP1 = GameObject.FindWithTag("VirtualCameraP1");
        VcameraP2 = GameObject.FindWithTag("VirtualCameraP2");
        float y_dump = 0f;
        if (inside)
        {
            if (gameObject.layer == 11){ 
                cvc = VcameraP1.GetComponent<CinemachineVirtualCamera>();
                ct = cvc.GetCinemachineComponent<CinemachineTransposer>();
                y_dump = ct.m_YDamping;
                ct.m_YDamping = 0; 
                _anim.SetBool("Slide", true);
                _cc.enabled = false;
                transform.Rotate(new Vector3(10f, 0f, 0f));
            //_rigibody.useGravity = false;
                inSlide = !inSlide;
            }
            else{
                cvc = VcameraP2.GetComponent<CinemachineVirtualCamera>();
                ct = cvc.GetCinemachineComponent<CinemachineTransposer>();
                y_dump = ct.m_YDamping;
                ct.m_YDamping = 0; 
                _anim.SetBool("Slide", true);
                _cc.enabled = false;
                transform.Rotate(new Vector3(10f, 0f, 0f));
            //_rigibody.useGravity = false;
                inSlide = !inSlide;
            }
        }
        else
        {
            if (gameObject.layer == 11){
                cvc = VcameraP1.GetComponent<CinemachineVirtualCamera>();
                ct = cvc.GetCinemachineComponent<CinemachineTransposer>();
                ct.m_YDamping = 5.76f; 
                _anim.SetBool("Slide", false);
                transform.Rotate(new Vector3(-10f, 0f, 0f));
                _cc.enabled = true;
                inSlide = !inSlide;
            }
            else{
                cvc = VcameraP2.GetComponent<CinemachineVirtualCamera>();
                ct = cvc.GetCinemachineComponent<CinemachineTransposer>();
                ct.m_YDamping = 5.76f;
                 _anim.SetBool("Slide", false);
                transform.Rotate(new Vector3(-10f, 0f, 0f));
                _cc.enabled = true;
                inSlide = !inSlide;

            }
            
            //_rigibody.useGravity = true;

        }
    }

    IEnumerator Teleport()
    {
        //_rigibody.useGravity = false;
        _cc.enabled = false;
        //_cc.detectCollisions = true;
        //_cc.enableOverlapRecovery = true;

        yield return new WaitForSeconds(2f);
        gameObject.transform.position = PosInicial.position;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        _cc.enabled = true;
        _anim.SetBool("Die",false);
    }

    IEnumerator WinTimer()
    {
        _cc.enabled = false;
        SoundManager.PlaySound("win");
        _anim.SetBool("Win", true);
        yield return new WaitForSeconds(5f);
        if (SceneManager.GetActiveScene().buildIndex < 5) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else SceneManager.LoadScene(0);
        _cc.enabled = true;
    }

    public void win(){
        StartCoroutine("WinTimer");

    }

    public void changeVelocityToZero(){
        speed = 0;
    }
    public void changeVelocityToNormal(){
        speed = 5;
    }
    public void updateInitialPos(Transform updatedPos){ 
        Vector3 position = updatedPos.position;
        //position.x = transform.position.x;
        //position.y = transform.position.y;
        position.z = updatedPos.position.z;
        PosInicial.position = position;
    }
}
