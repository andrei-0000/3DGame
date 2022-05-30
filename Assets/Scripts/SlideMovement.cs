using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Movement>().goSlide(true);
    }
    
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Movement>().goSlide(false);
    }
}
