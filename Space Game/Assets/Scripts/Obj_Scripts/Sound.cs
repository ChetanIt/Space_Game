using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound : MonoBehaviour
{
    public string name_;

    public float volume, pitch;
    public AudioClip clip;
    

    [HideInInspector]
    public AudioSource source;
}
