using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    //Movemnet
    public float move_speed;
    Rigidbody2D rb;
    Vector2 movement;

    //Mouse Look
    Camera cam;
    Vector2 mousePos;

    //Shooting
    [SerializeField]
    GameObject bullet;
    public float bul_speed;
    [SerializeField]
    Transform fire_Pos;
    public float fire_rate;
    //Next Time to Fire
    float NTTF;
    //Number of shots
    int NOS = 3;
    //float spread = 30;
    //Defines current gun scriptable obj
    public Gun_Obj cur_Gun;

    //Score System
    public int cur_Score;
    [SerializeField]
    TextMeshProUGUI score_display;

    //Money System
    public int cur_amount;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();
        rb.gravityScale = 0;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //Remove if statement after development
       if(score_display != null) 
        score_display.text = "Score:" + cur_Score;

       if(cur_Gun != null) { bul_speed = cur_Gun.bul_speed; fire_rate = cur_Gun.fire_rate; NOS = cur_Gun.num_of_buls; }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * move_speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        if (Input.GetButton("Fire1") && Time.time >= NTTF)
        {
            Shoot();
            NTTF = Time.time + 1f / fire_rate;
        }
    }

    void Shoot()
    {

       
            GameObject bul = Instantiate(bullet, fire_Pos.position, fire_Pos.transform.rotation);
            Rigidbody2D bul_rb = bul.GetComponent<Rigidbody2D>();
            bul_rb.AddForce(fire_Pos.up * bul_speed, ForceMode2D.Impulse);
           
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Coin"))
        {
            AddAmount();
        }
    }

    public void AddScore(int STBA)
    {
        cur_Score += STBA;
    }

    public void AddAmount()
    {
        //Add code later
        //cur_amount += ATBA;
    }
}
