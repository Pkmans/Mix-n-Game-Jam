using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    public AudioSource hurtSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("orangeEnemy")) {
            health--;
            hurtSound.Play();
        }
    }
}
