using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shurikenScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform weaponTip;

    public float numOfShurikens;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private AudioSource shotSound;

    public float burstTime;

    //pass values to shuriken
    private Vector3 bulletDir;


    // Start is called before the first frame update
    void Start()
    {
        shotSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rotateWeapon();

        //shoot bullet
        if (timeBtwShots <= 0 && Input.GetMouseButtonDown(0)) {

            //get direction
            bulletDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            bulletDir.z = 0;
            bulletDir.Normalize();

            StartCoroutine(spawnShuriken(bulletDir));

            timeBtwShots = startTimeBtwShots;
            
        } else
            timeBtwShots -= Time.deltaTime;
    }



    void rotateWeapon() {
        //rotate weapon to mouse
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90 || rotationZ > 90) {
            transform.localRotation = Quaternion.Euler(180f, 0f, -rotationZ);
        }
    }

    IEnumerator spawnShuriken(Vector3 bulletDir) {

        for (int i = 0; i < numOfShurikens; i++) {
            GameObject bullet = Instantiate(bulletPrefab, weaponTip.position, transform.rotation);
            bullet.GetComponent<shurikenBullet>().setDir(bulletDir);
            shotSound.Play();

            yield return new WaitForSeconds(burstTime);
        }
    }
}
