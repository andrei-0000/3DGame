using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPosition : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other){
        other.gameObject.GetComponent<Movement>().goLeft();
    }

}