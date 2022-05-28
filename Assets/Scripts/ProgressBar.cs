using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private float targetProgress = 0;
    private ParticleSystem particleSys;
    public float FillSpeed = 0.25f;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        particleSys = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += FillSpeed * Time.deltaTime;
            if (!particleSys.isPlaying) particleSys.Play();
        }
        else
        {
            particleSys.Stop();
        }
        
    }

    public void reset()
    {
        slider.value = 0;
        targetProgress = 0;
    }


    public void IncrementProgress(float newProgress) { 

        targetProgress = slider.value + newProgress; }
}
