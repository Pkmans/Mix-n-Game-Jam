using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public AudioSource hitSound;

    public float speed;
    public GameObject particles;

    private Vector3 bulletDir;

    // Start is called before the first frame update
    void Start()
    {
        bulletDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        bulletDir.z = 0;
        bulletDir.Normalize();

        Destroy(gameObject, 3f);

        // hitSound = GetComponent<AudioSource>();
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
        hitSound.Play();
        Instantiate(particles, transform.position, Quaternion.identity);

        //hide before delay destroying
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        Destroy(gameObject, 0.5f);
    }
}
