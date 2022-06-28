using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float retreat_Distance, stopping_Distance, detect_Distance, mov_speed;
    //Number of Bullets
    public int NOB;
    Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Enemy can detect the Player
        if(Vector2.Distance(player.position, transform.position) <= detect_Distance)
        {
            if (Vector2.Distance(player.position, transform.position) > stopping_Distance) { } //Vector2.MoveTowards(player.position, mov_speed);
        }

    }
}
