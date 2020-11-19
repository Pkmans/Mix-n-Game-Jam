using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    public GameObject tnt, shield;

    public Transform left, right;

    public float tntTimer;
    private float tntTimerLeft;

    public float shieldTimer;
    private float shieldTimerLeft;

    // Start is called before the first frame update
    void Start()
    {
        tntTimerLeft = tntTimer;
        shieldTimerLeft = shieldTimer;
    }

    // Update is called once per frame
    void Update()
    {
        Tnt();
        Shield();
    }

    void Tnt() {
        if (tntTimerLeft <= 0) {
            SpawnTnt();
            tntTimerLeft = tntTimer;
        }
        else
            tntTimerLeft -= Time.deltaTime;
    }

    //tnt helper
    void SpawnTnt() {
        Vector3 pos = RandomPos();
        Instantiate(tnt, pos, Quaternion.identity);
    }

    void Shield() {
        if (shieldTimerLeft <= 0) {
            SpawnShield();
            shieldTimerLeft = shieldTimer;
        }
        else
            shieldTimerLeft -= Time.deltaTime;
    }

    //shieldhelper
    void SpawnShield() {
        Vector3 pos = RandomPos();
        Instantiate(shield, pos, Quaternion.identity);
    }


    ///helper funcs
    Vector3 RandomPos() {
        float x1 = left.position.x;
        float x2 = right.position.x;

        Vector3 pos = new Vector3(Random.Range(x1, x2), right.position.y);
        return pos;
    }
}
