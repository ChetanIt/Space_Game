using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Particle_Manager : MonoBehaviour
{
    public Particles[] effects;
    public static Particle_Manager instance;

    private void Awake()
    {
        instance = this;
    }

    public void Play_Effect(int id  , Vector3 pos, Color col)
    {
      Particles p =  Array.Find(effects, x => x.id == id);
        if (p != null) 
        { 
            GameObject g = Instantiate(p.effect, pos, p.effect.transform.rotation);
            g.GetComponent<ParticleSystem>().startColor = col;
            Destroy(g, 2f);
        }


    }
}
