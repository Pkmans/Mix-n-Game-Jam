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

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        hpBar.setMaxHealth(maxHp);

        respawnPoint = GameObject.Find("respawn Point").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp < 0) {
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
        //turn on death UI
        deadUI.SetActive(true);
    }

    public void respawn() {
        transform.position = respawnPoint.position;

        //reset hp
        currentHp = maxHp;
        hpBar.setMaxHealth(maxHp);
    }


}
