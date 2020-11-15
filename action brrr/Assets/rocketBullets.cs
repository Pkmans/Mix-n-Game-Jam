using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketBullets : MonoBehaviour
{
    public float strength = 5f;
    public float radius = 3.5f;

    public AudioSource explodeSound;

    public float speed;
    public GameObject particles;

    private Vector3 bulletDir;

    //camera
    private cameraShake cameraShake;

    // Start is called before the first frame update
    void Start()
    {
        bulletDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        bulletDir.z = 0;
        bulletDir.Normalize();

        cameraShake = GameObject.Find("Main Camera").GetComponent<cameraShake>();

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletDir * speed * Time.deltaTime;
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
                rb.AddForce(dir, ForceMode2D.Impulse);
            }

            //damage enemy
            if (col.gameObject.GetComponent<enemyHealth>()) {
                col.gameObject.GetComponent<enemyHealth>().takeDamage(2);
            }
            
        }

        explodeSound.Play();
        Instantiate(particles, transform.position, Quaternion.identity);

        StartCoroutine(cameraShake.Shake(0.25f, 0.15f));

        //hide before delay destroying
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        Destroy(gameObject, 0.5f);
    }
}
