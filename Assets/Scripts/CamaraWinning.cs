using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamaraWinning : MonoBehaviour
{
  
    // Start is called before the first frame update
    public GameObject cameraP1;
    public GameObject cameraP2;
    [SerializeField]
    private CinemachineVirtualCamera cvc;
    [SerializeField]
    private CinemachineTransposer ct;
    public void changeCamara(){
        cameraP1 = GameObject.FindWithTag("VirtualCameraP1");
        cameraP2 = GameObject.FindWithTag("VirtualCameraP2");
            if (gameObject.layer == 11){ //player 1
                cvc = cameraP1.GetComponent<CinemachineVirtualCamera>();
                cvc.m_Lens.FieldOfView = 20f;
                transform.Rotate(new Vector3(0, 180f, 0f));
                ct = cvc.GetCinemachineComponent<CinemachineTransposer>();
               // ct.m_BindingMode = ;
        }
        else{ //player 2
            cvc = cameraP2.GetComponent<CinemachineVirtualCamera>();
            cvc.m_Lens.FieldOfView = 15f;

        }
    }
}
