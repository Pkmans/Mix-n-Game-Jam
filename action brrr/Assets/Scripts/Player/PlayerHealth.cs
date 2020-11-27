using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //hp
    public int maxHp = 5;
    private int currentHp;
    public HealthBar hpBar;

    public GameObject deathParticles;

    //random
    public AudioSource hurtSound, playerDeath;
    public cameraShake cameraShake;
    private Transform respawnPoint;

    //shield 
    public GameObject shield;
    public float shieldDuration;
    private bool invulnerable;

    private GameManager GameManager;
    private bool dead;
    private AudioSource BGM;

    private SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        respawnPoint = GameObject.Find("respawn Point").transform;
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        BGM = GameObject.Find("BGM").GetComponent<AudioSource>();

        currentHp = maxHp;
        hpBar.setMaxHealth(maxHp);
    }

    // Update is called once per frame
    void Update()
    {
        //player invulnerable if shield is active;
        invulnerable = shield.activeSelf;
    }

    public void takeDamage(int damage) {
        if (invulnerable || dead) return;

        StartCoroutine(DamageFlash());

        currentHp -= damage;
        hpBar.setHealth(currentHp);
        hpBar.damageAnimation();

        hurtSound.Play();

        if (currentHp <= 0)
            die();
        
        //add a knockback effect?

        StartCoroutine(cameraShake.Shake(0.15f, 0.2f));
    }

    void die() {
        dead = true;
        BGM.volume = 0.02f;

        //death particles & screenshake
        Instantiate(deathParticles, transform.position, deathParticles.transform.rotation);
        playerDeath.Play();
        
        Destroy(gameObject);
  
        GameManager.onPlayerDeath();
    }

    ///SHIELD CODE

    public void activateShield() {
        StartCoroutine(activateShieldCoroutine());
    }

    IEnumerator activateShieldCoroutine() {
        shield.SetActive(true);

        yield return new WaitForSeconds(shieldDuration);

        shield.SetActive(false);
    }


    void takeAcidDamage(int damage) {
        if (dead) return;

        currentHp -= damage;
        hpBar.setHealth(currentHp);
        hpBar.damageAnimation();

        hurtSound.Play();

        if (currentHp <= 0)
            die();

        StartCoroutine(cameraShake.Shake(0.1f, 0.2f));
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.layer == 12) {
            takeAcidDamage(maxHp);
        }
    }

    IEnumerator DamageFlash() {
		sprite.color = new Color(1, 0.4f, 0.4f, 1f);
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color (1, 1, 1, 1);
	}

}
