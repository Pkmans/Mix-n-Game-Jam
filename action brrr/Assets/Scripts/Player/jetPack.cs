using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jetPack : MonoBehaviour
{
    public float strength;
    public GameObject smokeParticles;
    public ParticleSystem fireParticles;

    private AudioSource jetpackSound;

    public float maxFlySpeed;

    public float timeMax;
    private float timeLeft;

    public jetpackBar jetpackBar;
    
    private PlayerMovement player;
    private Rigidbody2D rb;

    private bool ready;

    // Start is called before the first frame update
    void Start()
    {
        jetpackSound = GetComponent<AudioSource>();
        player = GetComponentInParent<PlayerMovement>();
        rb = player.rb;

        timeLeft = timeMax;

        jetpackBar.setMaxBar(timeMax);

        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        float xVel = rb.velocity.x;
        float yVel = rb.velocity.y;


        //reset jetpack duration if grounded
        if (timeLeft != timeMax && player.isGrounded) {
            jetpackBar.setMaxBar(timeMax);
            timeLeft = timeMax;

            ready = true; 
        }
    
        //play smoke particles if key pressed
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            if (!ready) return;

            if (yVel < -0.2f)
                rb.velocity = (new Vector2(xVel, 0));

            //effects
            Instantiate(smokeParticles, transform.position, smokeParticles.transform.rotation);
            fireParticles.Play();
            jetpackSound.Play();
        }

        //use jetpack if holding down key
        if (Input.GetKey(KeyCode.LeftShift) && timeLeft > 0 && ready) {
            
            if (yVel < maxFlySpeed)
                rb.AddForce(new Vector2(0, strength));

            timeLeft -= Time.deltaTime;

            //update bar
            jetpackBar.setBar(timeLeft);
            return;

        } else {
            fireParticles.Stop();
            jetpackSound.Stop();
        }

        if (timeLeft < 0)
            ready = false;

    
    }

}
