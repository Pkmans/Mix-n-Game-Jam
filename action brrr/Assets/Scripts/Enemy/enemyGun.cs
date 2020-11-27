using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunTip;

    private Transform player;

    //time variables
    public float startTimeBtwShots;
    private float timeBtwShots;

    private GameManager game;

    // Start is called before the first frame update
    void Start()
    {
        
        game = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (!game.player) return;
        
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!game.player) return;

        //rotate gun to player
        Vector3 diff = player.position - transform.position;
        diff.Normalize();

        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90 || rotationZ > 90) {
            transform.localRotation = Quaternion.Euler(180f, 0f, -rotationZ);
        }

        //shoot bullet
        if (timeBtwShots <= 0) {
            Instantiate(bulletPrefab, gunTip.position, transform.rotation);
            timeBtwShots = startTimeBtwShots;
        } else {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
