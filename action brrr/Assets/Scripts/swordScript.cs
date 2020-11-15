using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour
{
    public GameObject sword;
    private SpriteRenderer swordRenderer;

    public GameObject particles;
    public Transform swordTip;

    // Start is called before the first frame update
    void Start()
    {
        swordRenderer = sword.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Attack();
        }



        //rotate sword to mouse
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90 || rotationZ > 90) {
            transform.localRotation = Quaternion.Euler(180f, 0f, -rotationZ);
        }

    }

    void Attack() {
        swordRenderer.enabled = false;
        Invoke("enableRenderer", 0.25f);

        Instantiate(particles, swordTip.position, Quaternion.identity);
    }

    void enableRenderer() {
        swordRenderer.enabled = true;
    }

}
