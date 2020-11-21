using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //moveSpeed and inputs
    public float moveSpeed;
    public float maxMoveSpeed;
    private float turnSpeed = 3.2f;
    public float jumpForce;
    private float moveInput;

    //jumps
    public float extraJumpsValue;
    private float extraJumps;
    public GameObject jumpParticles;

    //groundchecks
    public bool isGrounded = false;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //flip sprite
    private SpriteRenderer sprite;
    private bool facingRight = true;

    [HideInInspector]
    public Rigidbody2D rb;

    private AudioSource jumpSound;
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
        extraJumps = extraJumpsValue;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal");

        //reset jump values
        if(isGrounded)
            extraJumps = extraJumpsValue;

        //jumps
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

    }

    void FixedUpdate() {
        //move input
        Move();

        //slow down player if no movement inputs
        if (moveInput == 0)
            slowDown();
        
    }

    void Jump() {
        if (extraJumps < 0) return;

        rb.velocity = new Vector2(rb.velocity.x, 0);

        rb.AddForce(new Vector2(0, jumpForce));
        
        //effects
        jumpSound.Play();
        anim.SetTrigger("jump");
        Instantiate(jumpParticles, groundCheck.position, Quaternion.identity);

        extraJumps--;
    }

    void Move() {
        Flip();

        float xVel = rb.velocity.x;

        if (Mathf.Abs(xVel) < maxMoveSpeed)
            rb.AddForce(new Vector2(moveInput * moveSpeed, 0));

        //turn player around faster
        if (xVel > 0.2f && moveInput < 0)
            rb.AddForce(new Vector2(moveInput * moveSpeed * turnSpeed, 0));
        if (xVel < -0.2f && moveInput > 0)
            rb.AddForce(new Vector2(moveInput * moveSpeed * turnSpeed, 0));

    }

    void slowDown() {
        if (rb.velocity.x > 0.2f)
            rb.AddForce(new Vector2(-moveSpeed, 0));
        if (rb.velocity.x < -0.2f)
            rb.AddForce(new Vector2(moveSpeed, 0));
    }

    void Flip() {
        if (facingRight && moveInput < 0) {
            facingRight = !facingRight;
            sprite.flipX = !sprite.flipX;
        }

        if (!facingRight && moveInput > 0) {
            facingRight = !facingRight;
            sprite.flipX = !sprite.flipX;
        }
    }


    ///collision events

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("movingPlatform"))
            transform.parent = col.transform.parent;
    }

    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.CompareTag("movingPlatform"))
            transform.parent = null;
    }
    

}
