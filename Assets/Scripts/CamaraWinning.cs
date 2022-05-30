using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamaraWinning : MonoBehaviour
{
  
    // Start is called before the first frame update
    public GameObject cameraP1;
    public GameObject cameraP2;
    public GameObject VcameraP1;
    public GameObject VcameraP2;
    public GameObject finalCamP1;
    public GameObject finalCamP2;
    private CharacterController _cc;
    private Camera c1;
    private Camera c2;
    private Camera fc;
    [SerializeField]
    private CinemachineVirtualCamera cvc;
    public void changeCamara(){
        _cc = GetComponent<CharacterController>();
        cameraP1 = GameObject.FindWithTag("MainCameraP1");
        cameraP2 = GameObject.FindWithTag("MainCameraP2");
        VcameraP1 = GameObject.FindWithTag("VirtualCameraP1");
        VcameraP2 = GameObject.FindWithTag("VirtualCameraP2");
        finalCamP1 = GameObject.FindWithTag("FinalCamP1");
        finalCamP2 = GameObject.FindWithTag("FinalCamP2");
            if (gameObject.layer == 11){ //player 1
                cvc = VcameraP1.GetComponent<CinemachineVirtualCamera>();
                cvc.m_Lens.FieldOfView = 20f;;
                c1 = cameraP1.GetComponent<Camera>();
                c2 = cameraP2.GetComponent<Camera>();
                fc = finalCamP1.GetComponent<Camera>();
                c1.enabled = false;
                c2.enabled = false;
                fc.enabled = true;
               _cc.enabled = false;
        }
        else{ //player 2
                cvc = VcameraP2.GetComponent<CinemachineVirtualCamera>();
                cvc.m_Lens.FieldOfView = 20f;  
                c1 = cameraP1.GetComponent<Camera>();
                c2 = cameraP2.GetComponent<Camera>();
                fc = finalCamP2.GetComponent<Camera>();
                c1.enabled = false;
                c2.enabled = false;
                fc.enabled = true;
               _cc.enabled = false;

        }
    }
}
