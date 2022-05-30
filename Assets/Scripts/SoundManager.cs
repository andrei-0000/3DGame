using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip hitSound, winSound, music;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        hitSound = Resources.Load<AudioClip>("hit");
        winSound = Resources.Load<AudioClip>("win");
        music = Resources.Load<AudioClip>("music");
        audioSrc = GetComponent<AudioSource>();
        if (audioSrc == null) audioSrc = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "hit":
                audioSrc.PlayOneShot(hitSound);
                break;
            case "win":
                audioSrc.PlayOneShot(winSound);
                break;
            case "music":
                audioSrc.PlayOneShot(music);
                break;
        }
    }

}
