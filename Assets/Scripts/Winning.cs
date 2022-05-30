using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winning : MonoBehaviour
{
    private ParticleSystem particleSys;

    private void Start()
    {
        particleSys = gameObject.GetComponentInChildren<ParticleSystem>();
        particleSys.Stop();
    }


    private void OnTriggerEnter(Collider other){
        if (!particleSys.isPlaying) particleSys.Play();
        other.gameObject.GetComponent<Movement>().win();
        other.gameObject.GetComponent<CamaraWinning>().changeCamara();
        
    }
}
