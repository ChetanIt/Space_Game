using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    public bool isExplode = false;
    public bool isSplit = false;
    public float rad;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy") && !isExplode) 
        {
            col.gameObject.GetComponent<Enemy>().Damage(1);
            DesObj(); 
        }

        if (col.gameObject.CompareTag("Enemy") && isExplode)
        {
            col.gameObject.GetComponent<Enemy>().Damage(1);
            Explode();
            DesObj();
        }

        if(col.gameObject.CompareTag("Game Manager"))
        {
            if (isExplode) { Explode(); }
            DesObj();
        }
    }

    void Explode()
    {
      
    }

    void DesObj()
    {
        if (!isExplode && !isSplit)
        {
            Particle_Manager.instance.Play_Effect(0, this.transform.position);
            Destroy(gameObject);
        } 

        else if(isExplode && !isSplit)
        {
            Explode();
            Destroy(gameObject);
        }
    }
}
