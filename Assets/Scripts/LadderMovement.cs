using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entra");
        other.gameObject.GetComponent<Movement>().goUp(true);
        Debug.Log("Entra2");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Sale");
        other.gameObject.GetComponent<Movement>().goUp(false);
        Debug.Log("Sale2");
    }
}
