using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlat : MonoBehaviour
{
	public float fallTime = 0.5f;

	Renderer myR;
    Collider myC;


	void OnCollisionEnter(Collision collision)
     {
        myR = GetComponent<Renderer>();
        myC = GetComponent<Collider>();
        StartCoroutine(Fall(fallTime));
        StartCoroutine(Reapper());
    
     }

	IEnumerator Fall(float time)
	{
		yield return new WaitForSeconds(time);
		myR.enabled = false;
        myC.enabled = false;
	}

	IEnumerator Reapper()
     {
         yield return new WaitForSeconds(4f);
         myR.enabled = true;
         myC.enabled = true;
         //gameObject.SetActive(true);
     }
}
