using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Particle_Manager : MonoBehaviour
{
    public Particle_Effect[] effects;

    public void Play_Effect(string name, Vector3 pos)
    {
      Particle_Effect p =  Array.Find(effects, x => x.name == name);
        if (p != null) 
        { 
            GameObject g = Instantiate(p.gameObject, pos, p.transform.rotation);
            Destroy(g, 2f);
        }


    }
}
