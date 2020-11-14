﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenEnemy : MonoBehaviour
{
    public GameObject deathParticles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("playerBullet")) {
            Instantiate(deathParticles, transform.position, deathParticles.transform.rotation);
            col.gameObject.GetComponent<bulletScript>().boom();
            Destroy(gameObject);
        }
    }
}