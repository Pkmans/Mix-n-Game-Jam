using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunTip;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private AudioSource shotSound;

    public float spread;

    // Start is called before the first frame update
    void Start()
    {
        shotSound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate gun to mouse
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90 || rotationZ > 90) {
            transform.localRotation = Quaternion.Euler(180f, 0f, -rotationZ);
        }


        //shoot bullets
        if (timeBtwShots <= 0) {
            if (Input.GetMouseButtonDown(0)) {

                //bullet spread
                GameObject topBullet = Instantiate(bulletPrefab, gunTip.position, transform.rotation);
                topBullet.transform.Rotate(0, 0, spread);
       

                GameObject middleBullet = Instantiate(bulletPrefab, gunTip.position, transform.rotation);


                GameObject bottomBullet = Instantiate(bulletPrefab, gunTip.position, transform.rotation);
                bottomBullet.transform.Rotate(0, 0, -spread);
   
                
                timeBtwShots = startTimeBtwShots;

                shotSound.Play();
            }
        } else {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
