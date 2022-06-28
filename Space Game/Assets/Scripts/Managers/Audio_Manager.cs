using UnityEngine.Audio;
using System;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        }    
    }

    public void Play_Sound(string name)
    {
       Sound s = Array.Find(sounds, Sound => Sound.name == name);
        if (s != null)
            s.source.Play();
        else return;

    }

}
