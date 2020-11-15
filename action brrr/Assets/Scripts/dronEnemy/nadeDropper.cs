using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nadeDropper : MonoBehaviour
{
    public GameObject nade;
    public Transform firePoint;

    public float startTimeBtwShots;
    private float timeBtwShots;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0) {
            shoot();
            timeBtwShots = startTimeBtwShots;
            
        }
        else{
            timeBtwShots -= Time.deltaTime;
        }
    }

    void shoot() {
        Instantiate(nade, firePoint.position, Quaternion.identity);
    }
}
