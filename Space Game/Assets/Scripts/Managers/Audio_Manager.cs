using UnityEngine.Audio;
using System;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public Sound[] sounds;
    public static Audio_Manager instance;

    private void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        }    

        instance = this;
    }

    public void Play_Sound(string name)
    {
       Sound s = Array.Find(sounds, Sound => Sound.name_ == name);
        if (s != null)
            s.source.Play();
        else return;

    }

}
