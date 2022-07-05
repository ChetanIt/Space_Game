using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    public static Player Instance;

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
    [SerializeField]
    float spread = 30;
    //Defines current gun scriptable obj
    public Gun_Obj cur_Gun;

    //Score System
    public int cur_Score;
    [SerializeField]
    TextMeshProUGUI score_display;

    //Money System
    public int cur_amount;

    //Health
    public int num_of_hearts;
    public int cur_health;
    float re;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();
        rb.gravityScale = 0;
        Instance = this;
        cur_health = num_of_hearts;
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

        LookAtMouse(mousePos);

        if (Input.GetButton("Fire1") && Time.time >= NTTF)
        {
            for (int i = 0; i < NOS; i++)
            {
                Shoot();
            } 
            NTTF = Time.time + 1f / fire_rate;
        }

        if (Input.GetKeyDown(KeyCode.Space)) TakeDamage();
    }

    void LookAtMouse(Vector3 tar)
    {
        Vector2 lookDir = transform.position - tar;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
    }

    void Shoot()
    {
        if(cur_Gun.bul_type == Gun_Obj.Bul_Type.Normal || cur_Gun.bul_type == Gun_Obj.Bul_Type.Missile)
        {
            if (NOS > 1)
            {
                GameObject b = Instantiate(bullet, fire_Pos.position, fire_Pos.transform.rotation);
                Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
                b.transform.Rotate(0, 0, spread);
                Vector2 dir = transform.rotation * Vector2.up;
                Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-spread, spread);
                brb.velocity = (dir + pdir) * bul_speed;

                if (cur_Gun.bul_type == Gun_Obj.Bul_Type.Missile)
                {
                    b.GetComponent<Player_Bullet>().isExplode = true;
                }
            }

            else
            {
                GameObject c = Instantiate(bullet, fire_Pos.position, fire_Pos.rotation);
                c.GetComponent<Rigidbody2D>().AddForce(fire_Pos.up * bul_speed, ForceMode2D.Impulse);

                if (cur_Gun.bul_type == Gun_Obj.Bul_Type.Missile)
                {
                    c.GetComponent<Player_Bullet>().isExplode = true;
                }
            }


        }

        else if(cur_Gun.bul_type == Gun_Obj.Bul_Type.Laser)
        {
            Debug.Log("Laser");
        }

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

    public void TakeDamage()
    {
       if(re == 0)
       {
            cur_health--;
            Audio_Manager.instance.Play_Sound("OnPlayerDamage");
            Invoke("ResetT", 2);
            re = 2;
       } 
    }
    
    void ResetT()
    {
        re = 0;
    }
}
