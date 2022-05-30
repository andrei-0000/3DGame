using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIncrement : MonoBehaviour
{
    private Transform updatedPos;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other){
        updatedPos = other.transform;
        other.gameObject.GetComponentInChildren<ProgressBar>().IncrementProgress(0.25f);
        other.gameObject.GetComponent<Movement>().updateInitialPos(updatedPos);
    }

}