using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square_Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    Transform player;
    [SerializeField]
    float det_dist;
    [SerializeField]
    float mov_speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = Player.Instance.transform;
        rb.gravityScale = 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, det_dist);
    }

    private void FixedUpdate()
    {
        if(Vector2.Distance(player.position, transform.position) <= det_dist)
        {
            var dire = player.position - transform.position;
            Vector2 move = dire;
            rb.MovePosition((Vector2)transform.position + (move * mov_speed * Time.deltaTime));

            var dir = player.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.TakeDamage();
        }
    }
}
