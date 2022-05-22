using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed, speedRotation, speedJump;
    private bool turnLeft, turnRight;
    private CharacterController _cc;
    private Vector3 initialPos;
    private Vector3 finalPos;
    //private Float xToRun;
   // private Float yToRun;
  //  private Float zToRun;
    // private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterController>();
        //_anim = GetComponent<Animator>();
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
        turnLeft = Input.GetKeyDown(KeyCode.A);
        turnRight = Input.GetKeyDown(KeyCode.D);

        //moure's cap a endavant
        if (Input.GetKey(KeyCode.W))
        {
            movement.z = 1;
            //_anim.SetBool("run", true);
        }
        //moure's cap a enrere
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _cc.SimpleMove(new Vector3(0f, 0f, 0f));
            _cc.Move(transform.forward * speed * Time.deltaTime);
        }
        //moure's a la dreta
        if (turnRight)
        {
            transform.Rotate(new Vector3(0, 90f, 0f));
        }

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


    void Move(Vector3 dir)
    {
        _cc.SimpleMove(dir.normalized * speed);

    }
}
