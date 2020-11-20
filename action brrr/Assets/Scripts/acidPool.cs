using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acidPool : MonoBehaviour
{
    public GameObject acidParticles;

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.layer == 8) return;

        Instantiate(acidParticles, col.gameObject.transform.position, acidParticles.transform.rotation);

        if (col.gameObject.CompareTag("Player") || col.gameObject.layer == 9) return;
        
        Destroy(col.gameObject);
    }
}
