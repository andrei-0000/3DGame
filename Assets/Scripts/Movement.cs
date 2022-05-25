using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed, speedJump;
    public bool turnLeft, turnRight;
    private CharacterController _cc;
    private Animator _anim;


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
        _cc = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (!Input.anyKey)
            _anim.SetBool("Moving", false);

        
        //moure's amb el click esquerra del mouse
        if (Input.GetKey(KeyCode.Mouse0))
        {
             _anim.SetBool("Moving", true);
            movement = transform.forward;
            Move(movement);
            
        }
        //moure's a la dreta
        if (turnRight)
        {
            transform.Rotate(new Vector3(0, 45f, 0f));
            turnRight = false;
        }

        //si rotem cap a la esquerra
        if (turnLeft)
        {
            transform.Rotate(new Vector3(0, -45f, 0f));
            turnLeft = false;
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

    /*void OnDisable()
    {
        triggerPosition.OnContact -= ChangePos;
    }*/

   /* void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PlaneRight") goRight();
    }*/
}
