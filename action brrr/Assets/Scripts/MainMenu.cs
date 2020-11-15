using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject player;

    public void startGame() {
        SceneManager.LoadScene(1);
    }

    public void rifle() {
        player.transform.Find("gun").gameObject.SetActive(true);
        player.transform.Find("shotgun").gameObject.SetActive(false);

    }

    public void shotgun() {
        player.transform.Find("gun").gameObject.SetActive(false);
        player.transform.Find("shotgun").gameObject.SetActive(true);
    }
}
