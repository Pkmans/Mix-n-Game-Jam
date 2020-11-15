using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jetPack : MonoBehaviour
{
    public float strength;
    public GameObject smokeParticles;
    public ParticleSystem fireParticles;

    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            Instantiate(smokeParticles, transform.position, smokeParticles.transform.rotation);
            fireParticles.Play();
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            
            Rigidbody2D rb = player.rb;
            rb.velocity = new Vector3(rb.velocity.x, strength);
            return;

        } else
            fireParticles.Stop();
            
    }

}
