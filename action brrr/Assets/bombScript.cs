using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    public AudioSource hitSound;

    public float force;
    public GameObject particles;

    private Vector3 bulletDir;
    private Rigidbody2D rb;

    //explosions
    public float strength;
    public float radius;
    

    // Start is called before the first frame update
    void Start()
    {
        hitSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();

        bulletDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        bulletDir.z = 0;
        bulletDir.Normalize();        

        Destroy(gameObject, 3f);

        rb.AddForce(bulletDir * force);
    }

    void OnCollisionEnter2D(Collision2D col) {
        boom();
    }

    public void boom() {
        //damage
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach(Collider2D col in colliders) {
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();

            //explosive force
            if (rb) {
                Vector2 dir = rb.position - GetComponent<Rigidbody2D>().position;
                dir.Normalize();
                rb.velocity = Vector2.zero;
                rb.AddForce(dir * strength, ForceMode2D.Impulse);
            }

            //damage enemy
            if (col.gameObject.GetComponent<enemyHealth>()) {
                col.gameObject.GetComponent<enemyHealth>().takeDamage(2);
            }
            
        }


        hitSound.Play();
        Instantiate(particles, transform.position, Quaternion.identity);

        //hide before delay destroying
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        Destroy(gameObject, 0.5f);
    }

    
    // void OnDrawGizmos() {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, radius);
    // }
}
