using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRightScript : MonoBehaviour
{

    public delegate void Contact();
    public event Contact OnContact;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnColliderEnter(Collider other)
    {
        if(OnContact != null)

            OnContact();

            other.gameObject.GetComponent<Movement>().goRight();

    }
}
