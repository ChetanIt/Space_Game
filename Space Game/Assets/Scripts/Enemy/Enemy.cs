using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float retreat_Distance, stopping_Distance, detect_Distance, mov_speed, fire_rate, bul_for;
    //Number of Bullets
    public int NOB;
    [SerializeField]
    Transform player, firePos;
    Rigidbody2D rb;


    public int Health;

    //Shooting
    [SerializeField]
    GameObject bullet;



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

        if (Vector2.Distance(player.position, transform.position) > stopping_Distance)
        {
            LookAtPlayer();
            MoveTowardsPlayer();
        }
        else if (Vector2.Distance(player.position, transform.position) < stopping_Distance && Vector2.Distance(player.position, transform.position) > retreat_Distance)
        {
            Shoot();
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(player.position, transform.position) < retreat_Distance)
        {
            Retreat();
        }
    }

    bool t = true;
    void Shoot()
    {
        if (t)
        {
            //Shooting Code
            GameObject b = Instantiate(bullet, firePos.position, firePos.rotation);
            Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
            brb.AddForce(firePos.up * bul_for, ForceMode2D.Impulse);

            //Reset Shooting
            t = false;
            Invoke("ResetS", fire_rate);
        }
    }

    void ResetS()
    {
        t = true;
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

    public void Damage(int d)
    {
        if (Health > 0) Health -= d;
        if (Health <= 0) Destroy(gameObject);
    }
}
