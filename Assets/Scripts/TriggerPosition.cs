using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPosition : MonoBehaviour
{

    public delegate void Contact();
    public event Contact OnContact;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other){
        other.gameObject.GetComponent<Movement>().goRight();
    }

}