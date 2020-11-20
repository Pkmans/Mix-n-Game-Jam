using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunTip;
    public float spread;
    public float numOfBullets = 3f;
 
    private float timeBtwShots;
    public float startTimeBtwShots;

    private AudioSource shotSound;

    //knockback Force
    public float knockbackForce;
    private PlayerMovement player;
    private Vector2 dir;
    


    // Start is called before the first frame update
    void Start()
    {
        shotSound = GetComponent<AudioSource>();
        player = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotate gun to mouse
        dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        dir.Normalize();

        float rotationZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90 || rotationZ > 90) {
            transform.localRotation = Quaternion.Euler(180f, 0f, -rotationZ);
        }

        //shoot bullets
        if (timeBtwShots <= 0 && Input.GetMouseButtonDown(0)) {
            Shoot();
            timeBtwShots = startTimeBtwShots;
        } else
            timeBtwShots -= Time.deltaTime;
    }

    void Shoot() {
        Debug.Log(dir);

        //bullet spread
        for (int i = 0; i < numOfBullets; i++) {
            GameObject bullet = Instantiate(bulletPrefab, gunTip.position, transform.rotation);
            bullet.transform.Rotate(0, 0, Random.Range(-spread, spread));
        }

        shotSound.Play();

        //knockback Force
        player.rb.AddForce(-dir * knockbackForce, ForceMode2D.Impulse);
    }
}
