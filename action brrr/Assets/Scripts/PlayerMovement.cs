using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //speed and inputs
    public float speed;
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

    [HideInInspector]
    public Rigidbody2D rb;

    private AudioSource jumpSound;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsValue;

        jumpSound = GetComponent<AudioSource>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if(isGrounded)
            extraJumps = extraJumpsValue;

        moveInput = Input.GetAxisRaw("Horizontal");
        
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0) {
            Jump();
            extraJumps--;
        } else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0) {
            Jump();
            extraJumps--;
        }
    
    }

    void Jump() {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        
        //effects
        jumpSound.Play();
        anim.SetTrigger("jump");

        Instantiate(jumpParticles, groundCheck.position, Quaternion.identity);
    }
}
