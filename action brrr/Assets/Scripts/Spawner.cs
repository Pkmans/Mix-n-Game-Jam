using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject boss;
    public GameObject[] spawnParticles;
    public GameObject bossParticles;

    public Transform left, right, top, bottom;

    public float startTimeBtwSpawn;
    private float timeBtwSpawn;

    //values
    public float timeBeforeIncrement = 10f;
    public float incrementRate = 0.2f;
    private float playTime;
    public float maxRate;

    //boss vars
    public float bossRate;
    private float bossTimer;
    private float maxAmount = 2;
    [HideInInspector]
    public float curAmount;

    // Start is called before the first frame update
    void Start()
    {
        bossTimer = bossRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawn <= 0) {
            StartCoroutine(SpawnEnemy());
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else {
            timeBtwSpawn -= Time.deltaTime;
        }

        //increase pace of game
        if (playTime >= timeBeforeIncrement && startTimeBtwSpawn > maxRate) {
            playTime = 0f;
            startTimeBtwSpawn -= incrementRate;
        } else
            playTime += Time.deltaTime;

        //spawn boss at intervals
        if(bossTimer <= 0 && curAmount < maxAmount) {
            StartCoroutine(spawnBoss());
            resetBossTimer();
        } else
            bossTimer -= Time.deltaTime;

    }

    IEnumerator SpawnEnemy() {
        int index = Random.Range(0, enemies.Length);
        GameObject enemyToSpawn = enemies[index];

        float x1 = left.position.x;
        float x2 = right.position.x;

        float y1 = top.position.y;
        float y2 = bottom.position.y;

        Vector3 pos = new Vector3(Random.Range(x1, x2), Random.Range(y1, y2));

        //spawn particles before enemy
        GameObject particles = Instantiate(spawnParticles[index], pos, Quaternion.identity);
        Destroy(particles, 1.5f);

        yield return new WaitForSeconds(1.5f);
        Instantiate(enemyToSpawn, pos, Quaternion.identity);
    }

    IEnumerator spawnBoss() {
        float x1 = left.position.x;
        float x2 = right.position.x;

        Vector3 pos = new Vector3(Random.Range(x1, x2), top.position.y);

        //spawn particles before boss+
        GameObject particles = Instantiate(bossParticles, pos, Quaternion.identity);
        Destroy(particles, 1.5f);

        yield return new WaitForSeconds(1.5f);
        Instantiate(boss, pos, Quaternion.identity);

        curAmount += 1;
    }

    void resetBossTimer() {
        bossTimer = bossRate;
    }

}
