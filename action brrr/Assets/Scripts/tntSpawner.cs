using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tntSpawner : MonoBehaviour
{
    public GameObject tnt;

    public Transform left, right;

    public float startTimeBtwSpawn;
    private float timeBtwSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawn <= 0) {
            Spawn();
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

    void Spawn() {

        float x1 = left.position.x;
        float x2 = right.position.x;


        Vector3 pos = new Vector3(Random.Range(x1, x2), right.position.y);

        Instantiate(tnt, pos, Quaternion.identity);
    }
}
