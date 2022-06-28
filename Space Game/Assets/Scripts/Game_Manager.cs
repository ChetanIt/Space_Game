using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    public float galaxy_Rad;

    private void Awake()
    {
        gameObject.transform.localScale = new Vector2(galaxy_Rad, galaxy_Rad);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector2[] pol_points = gameObject.AddComponent<PolygonCollider2D>().points;
        Destroy(sr);
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<EdgeCollider2D>().points = pol_points;
        Destroy(sr);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, galaxy_Rad);
    }
}
