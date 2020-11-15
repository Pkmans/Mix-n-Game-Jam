using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{

    public float strength = 10f;
    public float radius = 5f;

    public GameObject particles;

    public AudioSource explodeSound;

    private cameraShake cameraShake;

    void Start() {
        cameraShake = GameObject.Find("Main Camera").GetComponent<cameraShake>();
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Player") || col.gameObject.layer == 8)
            Explode();
    }
    
    void Explode() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach(Collider2D col in colliders) {
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();

            if (rb != null) {
                Vector2 dir = rb.position - GetComponent<Rigidbody2D>().position;

                rb.AddForce(dir, ForceMode2D.Impulse);
            }

            //damage player
            if (col.gameObject.GetComponent<PlayerHealth>()) {
                col.gameObject.GetComponent<PlayerHealth>().takeDamage(2);
            }
            
        }

        //effects
        StartCoroutine(cameraShake.Shake(0.25f, 0.2f));
        explodeSound.Play();
        Instantiate(particles, transform.position, Quaternion.identity);

        //delay destruction
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject, 0.25f);

    }
}
