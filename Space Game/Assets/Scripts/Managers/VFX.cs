using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VFX : MonoBehaviour
{

    public float speed;
    public float intensity = 0.20f;
    PostProcessVolume Volume;
    Vector2 vel;

    private void Start()
    {
        Volume = GetComponent<PostProcessVolume>();
    }

    private void Update()
    {
        vel = Player.Instance.GetComponent<Rigidbody2D>().velocity;
        if (vel.magnitude > speed)
            Volume.GetComponent<Vignette>().intensity.Override(intensity);

    }

}
