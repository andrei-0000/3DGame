using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winning : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other){
        other.gameObject.GetComponent<Movement>().win();
        other.gameObject.GetComponent<CamaraWinning>().changeCamara();
        
    }
}
