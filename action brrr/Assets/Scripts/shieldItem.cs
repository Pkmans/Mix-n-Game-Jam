using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldItem : MonoBehaviour
{
    private AudioSource shieldSound;

    void Start() {
        shieldSound = GameObject.Find("shieldSound").GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Player")) {

            PlayerHealth player = col.gameObject.GetComponent<PlayerHealth>();
            player.activateShield();

            shieldSound.Play();

            Destroy(this.gameObject);
        }
    }
}
