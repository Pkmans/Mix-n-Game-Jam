using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    
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
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletDir * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.layer == 8) { //ground layer
            boom();
        }
    }

    public void boom() {
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
