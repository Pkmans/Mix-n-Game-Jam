using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public GameObject deathParticles, acidParticles, scoreParticle;
    public int hp = 3;

    public int scoreValue = 100;

    private SpriteRenderer body;
    private scoreScript scoreScript;

    private Spawner spawner;
    private AudioSource deathSound;


    void Start() {
        body = GetComponent<SpriteRenderer>();
        scoreScript = GameObject.Find("Score").GetComponent<scoreScript>();
        spawner = GameObject.Find("enemySpawner").GetComponent<Spawner>();

        deathSound = GameObject.Find("enemyDeath").GetComponent<AudioSource>();
    }

    void Update() {
        if (hp <= 0) {
            Die();
        }
    }


    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("playerBullet")) {
            if (col.gameObject.GetComponent<bulletScript>())
                col.gameObject.GetComponent<bulletScript>().boom();
            
            if (col.gameObject.GetComponent<shotGunBullets>())
                col.gameObject.GetComponent<shotGunBullets>().boom();
            
            takeDamage(1);
        }

        if (col.gameObject.layer == 12) {
            Die();
            Instantiate(acidParticles, transform.position, acidParticles.transform.rotation);
        }
            
    }

    public void takeDamage(int dmg) {
        hp -= dmg;

        StartCoroutine(flash());
    }

    void Die() {
        Instantiate(deathParticles, transform.position, deathParticles.transform.rotation);
        Instantiate(scoreParticle, transform.position, scoreParticle.transform.rotation);
        
        
        if (gameObject.name == "fatEnemy(Clone)")
            spawner.curAmount -= 1;

        //death sound here
        deathSound.Play();

        scoreScript.addScore(scoreValue);
        Destroy(gameObject);
    }

    IEnumerator flash() {
        Color tmp = body.color;

        tmp.a = 0.3f;
        body.color = tmp;

        yield return new WaitForSeconds(0.08f);
        tmp.a = 1f;
        body.color = tmp;
    }

}
