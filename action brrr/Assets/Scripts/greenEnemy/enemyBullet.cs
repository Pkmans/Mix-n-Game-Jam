using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public float speed;
    public GameObject particles;

    private Transform player;
    private Vector3 bulletDir;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;

        bulletDir = player.position - transform.position;
        bulletDir.z = 0;
        bulletDir.Normalize();

        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletDir * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Player")) {
            col.gameObject.GetComponent<PlayerHealth>().takeDamage(1);
        }

        boom();
    }

    void boom() {
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
