using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //hp
    public int maxHp = 5;
    private int currentHp;
    public HealthBar hpBar;

    public AudioSource hurtSound;

    public GameObject deadUI;
    public cameraShake cameraShake;

    private Transform respawnPoint;
    private GameObject enemSpawner, tntSpawner;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        hpBar.setMaxHealth(maxHp);

        respawnPoint = GameObject.Find("respawn Point").transform;

        //reference to spawners
        enemSpawner = GameObject.Find("enemySpawner");
        tntSpawner = GameObject.Find("tntSpawner");

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp <= 0) {
            die();
        }
    }

    public void takeDamage(int damage) {
        currentHp -= damage;
        hpBar.setHealth(currentHp);

        hurtSound.Play();

        StartCoroutine(cameraShake.Shake(0.1f, 0.2f));
    }

    void die() {
        transform.position = new Vector3(50, 50, 0);
        deadUI.SetActive(true);

        enemSpawner.SetActive(false);
        tntSpawner.SetActive(false);
    }

    public void respawn() {
        transform.position = respawnPoint.position;

        //reset hp
        currentHp = maxHp;
        hpBar.setMaxHealth(maxHp);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.layer == 12) {
            takeDamage(maxHp);
        }
    }


}
