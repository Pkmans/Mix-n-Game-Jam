using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponChooser : MonoBehaviour
{
    public GameObject rifleObject, shotgunObject, rocketObject;

    public void chooseWeapon(bool rifle, bool shotgun, bool rocket) {
        if (rifle) {
            rifleObject.SetActive(true);
            shotgunObject.SetActive(false);
            rocketObject.SetActive(false);
        } 
        else if (shotgun) {
            rifleObject.SetActive(false);
            shotgunObject.SetActive(true);
            rocketObject.SetActive(false);
        }
        else {
            rifleObject.SetActive(false);
            shotgunObject.SetActive(false);
            rocketObject.SetActive(true);
        }
    }
}
