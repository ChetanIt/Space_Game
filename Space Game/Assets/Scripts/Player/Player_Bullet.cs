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
        if (col.gameObject.CompareTag("Enemy")) 
        {
            Destroy(col.gameObject);
            DesObj(col.gameObject); 
        }
        
        if (col.gameObject.CompareTag("Game Manager")) DesObj(this.gameObject);
    }
    void DesObj(GameObject col)
    {
        if (!isExplode && !isSplit)
        {
            Particle_Manager.instance.Play_Effect(0, this.transform.position, col.gameObject.GetComponent<SpriteRenderer>().color);
            Destroy(gameObject);
        } 
    }
}
