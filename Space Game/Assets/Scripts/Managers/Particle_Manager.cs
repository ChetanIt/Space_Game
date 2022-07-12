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

        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].id = i;
        }
    }

    public void Play_Effect(int id  , Vector3 pos, Color col)
    {
      Particles p =  Array.Find(effects, x => x.id == id);
        if (p != null) 
        { 
            GameObject g = Instantiate(p.effect, pos, p.effect.transform.rotation);
            var p1 = g.GetComponent<ParticleSystem>();
            var m = p1.main;
            m.startColor = col;
            Destroy(g, 2f);
        }


    }
}
