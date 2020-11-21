using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shurikenBullet : MonoBehaviour
{
    public AudioSource hitSound;

    public float speed;
    public GameObject particles;

    private Vector3 bulletDir;
    private float degreesPerSec = 1080f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
        hitSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletDir * speed * Time.deltaTime;
        spinBullet();
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

    void spinBullet() {
    
        float rotateAmount = degreesPerSec * Time.deltaTime; 
        float curRotate = transform.localRotation.eulerAngles.z; 
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRotate + rotateAmount));
    }

    public void setDir(Vector3 dir) {
        bulletDir = dir;
    }
}
