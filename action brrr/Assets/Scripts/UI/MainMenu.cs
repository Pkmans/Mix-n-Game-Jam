using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject mainMenu;
    public GameObject aboutMenu;

    public characterManager characterManager;

    private GameObject gun, shotgun1, rocket1;

    void Start() {
        gun = player.transform.Find("gun").gameObject;
        shotgun1 = player.transform.Find("shotgun").gameObject;
        rocket1 = player.transform.Find("rocket").gameObject;
    }

    public void startGame() {
        SceneManager.LoadScene(1);
    }

    public void about() {
        mainMenu.SetActive(false);
        aboutMenu.SetActive(true);
    }

    public void back() {
        aboutMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void quitGame() {
        Application.Quit();
    }

    public void openYoutube() {
        Application.OpenURL("https://www.youtube.com/watch?v=3PlvK2dmGiw");
    }

    public void rifle() {
        characterManager.rifleWeapon = true;
        characterManager.shotgunWeapon = false;
        characterManager.rocketWeapon = false;
        characterManager.shurikenWeapon = false;
        characterManager.bombWeapon = false;
    }

    public void shotgun() {
        characterManager.rifleWeapon = false;
        characterManager.shotgunWeapon = true;
        characterManager.rocketWeapon = false;
        characterManager.shurikenWeapon = false;
        characterManager.bombWeapon = false;
    }

    public void rocket() {
        characterManager.rifleWeapon = false;
        characterManager.shotgunWeapon = false;
        characterManager.rocketWeapon = true;
        characterManager.shurikenWeapon = false;
        characterManager.bombWeapon = false;
    }

    public void shuriken() {
        characterManager.rifleWeapon = false;
        characterManager.shotgunWeapon = false;
        characterManager.rocketWeapon = false;
        characterManager.shurikenWeapon = true;
        characterManager.bombWeapon = false;
    }
    
    public void bomb() {
        characterManager.rifleWeapon = false;
        characterManager.shotgunWeapon = false;
        characterManager.rocketWeapon = false;
        characterManager.shurikenWeapon = false;
        characterManager.bombWeapon = true;
    }
}
