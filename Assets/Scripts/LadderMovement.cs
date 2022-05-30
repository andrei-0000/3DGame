using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Movement>().goUp(true);
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Movement>().goUp(false);
    }
}
