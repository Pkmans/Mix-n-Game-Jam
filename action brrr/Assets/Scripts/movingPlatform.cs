using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col) {
        col.transform.parent = transform.parent;
    }

    void OnCollisionExit2D(Collision2D col) {
        col.transform.parent = null;
    }


}
