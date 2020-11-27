using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneBehaviour : MonoBehaviour
{
    public float jumpForce;
    public float speed = 2f;
    
    private Transform player;

    public float startTimeBtwJumps;
    private float timeBtwJumps;

    private Rigidbody2D rb;
    private GameManager game;



    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (!game.player) return;

        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!game.player) return;

        followPlayer();

        if (timeBtwJumps <= 0) {
            jump();
            timeBtwJumps = startTimeBtwJumps;
        }
         else {
            timeBtwJumps -= Time.deltaTime;
        }
    }

    void jump() {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void followPlayer() {
        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }
}
