using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class explosive : MonoBehaviour
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
        if (col.gameObject.CompareTag("playerBullet")) {
            if (col.gameObject.GetComponent<bulletScript>())
                col.gameObject.GetComponent<bulletScript>().boom();
            
            if (col.gameObject.GetComponent<shotGunBullets>())
                col.gameObject.GetComponent<shotGunBullets>().boom();
                
            Explode();
        }
    }

    void Explode() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach(Collider2D col in colliders) {
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();

            //explosive force
            if (rb) {
                Vector2 dir = rb.position - GetComponent<Rigidbody2D>().position;
                rb.AddForce(dir, ForceMode2D.Impulse);
            }

            //damage player
            if (col.gameObject.GetComponent<PlayerHealth>()) {
                col.gameObject.GetComponent<PlayerHealth>().takeDamage(2);
            }

            //damage enemy
            if (col.gameObject.GetComponent<enemyHealth>()) {
                col.gameObject.GetComponent<enemyHealth>().takeDamage(2);
            }
            
        }


        //effects
        StartCoroutine(cameraShake.Shake(0.4f, 0.2f));
        explodeSound.Play();
        Instantiate(particles, transform.position, Quaternion.identity);

        //delay destruction
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        transform.Find("light").gameObject.SetActive(false);
        Destroy(gameObject, 1f);

    }

    // void OnDrawGizmos() {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, radius);
    // }
}
