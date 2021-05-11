using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class restaurant_SoundManager : MonoBehaviour
{

    public static AudioClip goodSound, badSound;
    static AudioSource audioSrc;
    // Use this for initialization
    void Start()
    {
        goodSound = Resources.Load<AudioClip>("good");
        badSound = Resources.Load<AudioClip>("bad");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public static void PlaySound(string clip)
    {
        switch (clip){
            case "good":
                audioSrc.PlayOneShot(goodSound);
                break;
            case "bad":
                audioSrc.PlayOneShot(badSound);
                break;
        }
    }
}