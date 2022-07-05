using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Player.Instance.TakeDamage();
            DesObj();
        }
    }

    void DesObj()
    {
        Destroy(gameObject);
    }
}
