using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotGunBullets : MonoBehaviour
{
    public AudioSource hitSound;
    public GameObject particles;


    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);

        hitSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed  * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col) {
        boom();
    }

    public void boom() {
        hitSound.Play();
        Instantiate(particles, transform.position, Quaternion.identity);

        //hide before delay destroying
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        Destroy(gameObject, 0.5f);
    }
}
