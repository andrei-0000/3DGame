using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed, speedRotation, speedJump;

    private Rigidbody _rb;
    // private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        //_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector3(_rb.velocity.x, speedJump, _rb.velocity.z);
        }

        if (Input.GetKey(KeyCode.W))
        {
            _rb.velocity = new Vector3(transform.forward.x * speed, _rb.velocity.y, transform.forward.z * speed);
            //_anim.SetBool("run", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _rb.velocity = transform.forward * -speed;
            //_anim.SetBool("run", true);
        }

        /*if (!Input.anyKey)
            _anim.SetBool("run", false);*/

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, -speedRotation * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, speedRotation * Time.deltaTime, 0);

    }
}
