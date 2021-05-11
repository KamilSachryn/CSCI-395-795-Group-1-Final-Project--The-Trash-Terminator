using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class park_AudioManager : MonoBehaviour
{
    public park_Sound[] sounds;

    void Start()
    {
        foreach(park_Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
        }

        PlaySound("MainTheme");
    }

    public void PlaySound(string name)
    {
        foreach(park_Sound s in sounds)
        {
            if (s.name == name)
                s.source.Play();
        }
    }
}
