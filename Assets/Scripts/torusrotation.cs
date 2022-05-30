using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torusrotation : MonoBehaviour
{
   private float speed = 0.4f;


    // Update is called once per frame
    void Update()
    {
		transform.Rotate(0f, speed * Time.deltaTime / 0.01f, 0f, Space.Self);
	}
}
