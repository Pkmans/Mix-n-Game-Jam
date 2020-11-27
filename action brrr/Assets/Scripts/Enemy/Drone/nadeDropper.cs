using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nadeDropper : MonoBehaviour
{
    public GameObject nade;
    public Transform firePoint;

    public float startTimeBtwShots;
    private float timeBtwShots;

    private GameObject player;
    private GameManager game;


    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!game.player) return;


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
