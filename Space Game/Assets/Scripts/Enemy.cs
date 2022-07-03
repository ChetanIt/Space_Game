using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float retreat_Distance, stopping_Distance, detect_Distance, mov_speed;
    //Number of Bullets
    public int NOB;
    Transform player;
    Rigidbody2D rb;
    


    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detect_Distance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stopping_Distance);

    }

    void FixedUpdate()
    {
        if (Vector2.Distance(player.position, transform.position) <= detect_Distance) { LookAtPlayer();}
        if(Vector2.Distance(player.position, transform.position) <= detect_Distance && Vector2.Distance(player.position, transform.position) > stopping_Distance) { MoveTowardsPlayer(); }
        else if(Vector2.Distance(player.position, transform.position) < stopping_Distance) { Retreat(); }
    }

    void MoveTowardsPlayer()
    {
        var dire = player.position - transform.position;
        Vector2 movement = dire;
        rb.MovePosition((Vector2)transform.position + (movement * mov_speed * Time.deltaTime));
    }

    void Retreat()
    {
        var dire = player.position - transform.position;
        Vector2 movement = dire;
        rb.MovePosition((Vector2)transform.position + (-movement * mov_speed * Time.deltaTime));
    }

    void LookAtPlayer()
    {
        var dir = player.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
