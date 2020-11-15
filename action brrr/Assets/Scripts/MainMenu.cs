using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject mainMenu;
    public GameObject aboutMenu;

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

    public void rifle() {
        gun.SetActive(true);
        shotgun1.SetActive(false);
        rocket1.SetActive(false);
    }

    public void shotgun() {
        shotgun1.SetActive(true);
        gun.SetActive(false);
        rocket1.SetActive(false);
    }

    public void rocket() {
        gun.SetActive(false);
        shotgun1.SetActive(false);
        rocket1.SetActive(true);
    }
}
