using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public float horzSpeed;
    public float vertSpeed;
    public float switchTime;
    private float timeLeft;

    private Rigidbody2D rb;

    private float dir = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(horzSpeed, vertSpeed);
        
        timeLeft = switchTime;
    }

    void Update() 
    {
        //switch directions
        if (timeLeft <= 0 && dir > 0) {

            rb.velocity = new Vector2(-horzSpeed, -vertSpeed);
            dir = -1;

            timeLeft = switchTime;
            return;
        }
        if (timeLeft <= 0 && dir < 0) {

            rb.velocity = new Vector2(horzSpeed, vertSpeed);
            dir = 1;

            timeLeft = switchTime;
            return;
        }
            
        timeLeft -= Time.deltaTime;
    }


}
