using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPosition : MonoBehaviour
{

    public delegate void Contact();
    public event Contact OnContact;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnColliderEnter(Collider other){   
        if(OnContact != null)
            OnContact();

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
