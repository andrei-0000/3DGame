using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed, speedRotation, speedJump;

    private CharacterController _cc;
    public Vector3 finalPos;
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

        //moure's cap a endavant
        if (Input.GetKey(KeyCode.W))
        {
            movement.z = 1;
            //_anim.SetBool("run", true);
        }
        //moure's cap a enrere
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(transform.position.z > finalPos.z){
                movement.z = -1;
            }

            //_anim.SetBool("run", true);
        }
        //moure's a la dreta
        if (Input.GetKey(KeyCode.D))
        {
            movement.x = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1;
            //_anim.SetBool("run", true);
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
