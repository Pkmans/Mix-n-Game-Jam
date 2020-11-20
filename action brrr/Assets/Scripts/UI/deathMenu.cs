using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class deathMenu : MonoBehaviour
{
    public GameObject deadUI;
    private PlayerHealth player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    public void restart() {
        SceneManager.LoadScene(0);
    }

    public void quitGame() {
        Application.Quit();
    }
}
