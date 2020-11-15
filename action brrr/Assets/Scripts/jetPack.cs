using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jetPack : MonoBehaviour
{
    public float strength;
    public GameObject smokeParticles;
    public ParticleSystem fireParticles;

    public float timeMax;
    private float timeLeft;

    public float rechargeSpeed = 2f;

    public jetpackBar jetpackBar;
    
    private PlayerMovement player;

    private bool ready;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerMovement>();
        timeLeft = timeMax;

        jetpackBar.setMaxBar(timeMax);

        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft != timeMax && player.isGrounded) {
            jetpackBar.setMaxBar(timeMax);
            timeLeft = timeMax;
        }
    

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            Instantiate(smokeParticles, transform.position, smokeParticles.transform.rotation);
            fireParticles.Play();

            ready = true; 
        }

        if (Input.GetKey(KeyCode.LeftShift) && timeLeft > 0 && ready) {
            
            Rigidbody2D rb = player.rb;
            rb.velocity = new Vector3(rb.velocity.x, strength);

            timeLeft -= Time.deltaTime;

            //update bar
            jetpackBar.setBar(timeLeft);
            return;

        } else {
            fireParticles.Stop();
        }

        if (timeLeft < 0)
            ready = false;

        
        
    }

}
