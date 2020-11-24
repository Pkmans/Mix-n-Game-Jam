using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenEnemy : MonoBehaviour
{
    public float speed;
    public float maxSpeed;

    private SpriteRenderer sprite;
    private bool facingRight = false;

    private Transform player;
    private Vector3 dir;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.Find("Player").transform;
    }

    void Update() 
    {
        dir = player.position - transform.position;
        dir.z = 0;
        dir.Normalize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Flip();
        Move();
    }

    void Flip() {
        if (facingRight && dir.x < 0) {
            sprite.flipX = !sprite.flipX;
            facingRight = !facingRight;
        }
            
        if (!facingRight && dir.x > 0) {
            sprite.flipX = !sprite.flipX;
            facingRight = !facingRight;
        }
    }

    void Move() {
        float xVel = rb.velocity.x;

        if (Mathf.Abs(xVel) < maxSpeed)
            rb.AddForce(new Vector2(dir.x * speed, 0));
    }

}
