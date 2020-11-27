using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orangeEnemy : MonoBehaviour
{
    public float jumpForce;
    public float sidewaysForce;

    private Transform player;
    private Rigidbody2D rb;
    
    //particles
    public GameObject jumpParticles;

    //time variables
    public float startTimeBtwJumps = 2f;
    private float timeBtwJumps;

    private Animator anim;
    private AudioSource jumpSound;

    private SpriteRenderer sprite;
    private bool facingRight = true;

    private GameManager game;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        game = GameObject.Find("GameManager").GetComponent<GameManager>();


        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        timeBtwJumps = startTimeBtwJumps;
    }

    // Update is called once per frame
    void Update()
    {
        if (!game.player) return;

        if (timeBtwJumps <= 0) {
            jump();
            timeBtwJumps = startTimeBtwJumps;
        }
        else
            timeBtwJumps -= Time.deltaTime;
    }

    void jump() {
        Vector3 dir = player.position - transform.position;
        dir.z = 0;
        dir.Normalize();

        //flip and jump
        Flip(dir.x);
        rb.AddForce(new Vector2(dir.x * sidewaysForce, jumpForce));

        //effets
        anim.SetTrigger("jump");
        jumpSound.Play();
        Instantiate(jumpParticles, transform.position, jumpParticles.transform.rotation);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Player"))
            col.gameObject.GetComponent<PlayerHealth>().takeDamage(1);
    }

    void Flip(float dir) {
        if (facingRight && dir < 0) {
            sprite.flipX = !sprite.flipX;
            facingRight = !facingRight;
        }
            
        if (!facingRight && dir > 0) {
            sprite.flipX = !sprite.flipX;
            facingRight = !facingRight;
        }
    }
}
