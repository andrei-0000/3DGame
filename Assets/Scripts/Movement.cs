using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed, speedRotation, speedJump;
  
    public bool turnLeft, turnRight;
    private CharacterController _cc;
    private Vector3 initialPos;
    [SerializeField]
    private Vector3 finalActualPos;
    private Vector3[] positions;
    [SerializeField]
    private int it;

    public TriggerPosition triggerPosition;
    //private Float xToRun;
   // private Float yToRun;
  //  private Float zToRun;
    // private Animator _anim;
    // Start is called before the first frame update

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
        turnLeft = turnRight = false;
        it = 0;
        _cc = GetComponent<CharacterController>();
        //_anim = GetComponent<Animator>();
        positions = new Vector3[]{new Vector3(-2.831235f,0.8866265f,-55.69607f), new Vector3(-35.22f,-1.107f,-61.78f)};
        finalActualPos = positions[it];
        triggerPosition.OnContact += ChangePos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
        /*
        xToRun = finalPos.x - initialPos.x;
        yToRun = finalPos.y - initialPos.y;
        zToRun = finalPos.z - initialPos.z;
*/
        //moure's amb el click esquerra del mouse
        if (Input.GetKey(KeyCode.Mouse0))
        {
            movement = transform.forward;
            Move(movement);
            
        }
        //moure's a la dreta
        if (turnRight)
        {
            transform.Rotate(new Vector3(0, 90f, 0f));
        }

        //si rotem cap a la esquerra
        if (turnLeft)
        {
            transform.Rotate(new Vector3(0, -90f, 0f));
        }

        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector3(_rb.velocity.x, speedJump, _rb.velocity.z);
        }

        

       

        if (!Input.anyKey)
            _anim.SetBool("run", false);*/
        Move(movement);
    }

    private void ChangePos(){
        if(it < positions.Length) it++;
    }


    void Move(Vector3 dir)
    {
        _cc.SimpleMove(dir.normalized * speed);

    }

    void OnDisable()
    {
        triggerPosition.OnContact -= ChangePos;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PlaneRight") goRight();
    }
}
