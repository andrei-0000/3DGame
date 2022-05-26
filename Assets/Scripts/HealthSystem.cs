using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private CharacterController _cc;
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void killpl(){
        Debug.Log("hola");
        _anim.SetBool("Die",true);
        transform.position = new Vector3(-4.2f,1.39f,5.48f);
    }
}
