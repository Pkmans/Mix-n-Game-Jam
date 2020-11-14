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
    public GameObject deathParticles;

    //time variables
    public float startTimeBtwJumps = 2f;
    private float timeBtwJumps;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        timeBtwJumps = startTimeBtwJumps;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwJumps <= 0) {
            jump();
            timeBtwJumps = startTimeBtwJumps;
        }
        else {
            timeBtwJumps -= Time.deltaTime;
        }
    }

    void jump() {
        Vector3 dir = player.position - transform.position;
        dir.z = 0;
        dir.Normalize();

        rb.velocity = new Vector2(dir.x * sidewaysForce, jumpForce);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("playerBullet")) {
            Instantiate(deathParticles, transform.position, deathParticles.transform.rotation);
            col.gameObject.GetComponent<bulletScript>().boom();
            Destroy(gameObject);
        }
    }

}
