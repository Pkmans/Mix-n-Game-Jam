using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldItem : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Player")) {

            PlayerHealth player = col.gameObject.GetComponent<PlayerHealth>();

            player.activateShield();

            Destroy(this.gameObject);
        }
    }
}
