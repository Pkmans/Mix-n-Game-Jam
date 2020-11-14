using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed;
    private Vector3 bulletDir;

    // Start is called before the first frame update
    void Start()
    {
        bulletDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        bulletDir.z = 0;
        bulletDir.Normalize();

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletDir * speed * Time.deltaTime;
    }
}
