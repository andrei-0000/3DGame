using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entra");
        other.gameObject.GetComponent<Movement>().goSlide(true);
        Debug.Log("Entra2");
    }
    
        private void OnTriggerExit(Collider other)
        {
            Debug.Log("Sale");
            other.gameObject.GetComponent<Movement>().goSlide(false);
            Debug.Log("Sale2");
        }
}
