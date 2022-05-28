using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIncrement : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other){
        other.gameObject.GetComponentInChildren<ProgressBar>().IncrementProgress(0.25f);
    }

}