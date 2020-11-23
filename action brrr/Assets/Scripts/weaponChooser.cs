using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponChooser : MonoBehaviour
{
    public GameObject rifleObject, shotgunObject, rocketObject, shurikenObject, bombObject;

    public void chooseWeapon(bool rifle, bool shotgun, bool rocket, bool shuriken, bool bomb) {
        if (rifle) {
            rifleObject.SetActive(true);
            shotgunObject.SetActive(false);
            rocketObject.SetActive(false);
            shurikenObject.SetActive(false);
            bombObject.SetActive(false);
        } 
        else if (shotgun) {
            rifleObject.SetActive(false);
            shotgunObject.SetActive(true);
            rocketObject.SetActive(false);
            shurikenObject.SetActive(false);
            bombObject.SetActive(false);
        }
        else if (rocket){
            rifleObject.SetActive(false);
            shotgunObject.SetActive(false);
            rocketObject.SetActive(true);
            shurikenObject.SetActive(false);
            bombObject.SetActive(false);
        } else if (shuriken) {
            rifleObject.SetActive(false);
            shotgunObject.SetActive(false);
            rocketObject.SetActive(false);
            shurikenObject.SetActive(true);
            bombObject.SetActive(false);
        } else if (bomb) {
            rifleObject.SetActive(false);
            shotgunObject.SetActive(false);
            rocketObject.SetActive(false);
            shurikenObject.SetActive(false);
            bombObject.SetActive(true);
        }
    }
}
