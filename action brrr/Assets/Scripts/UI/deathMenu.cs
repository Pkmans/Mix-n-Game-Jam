using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class deathMenu : MonoBehaviour
{
    public GameObject deadUI;
    public GameObject pauseMenu;
    public AudioSource BGM;

    private PlayerHealth player;

    private float defaultVolume;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerHealth>();
        defaultVolume = BGM.volume;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseGame();
        }
            
    }

    public void restart() {
        SceneManager.LoadScene(1);
    }

    public void mainMenu() {
        Time.timeScale = 1f;
        BGM.volume = defaultVolume;

        SceneManager.LoadScene(0);
    }

    public void quitGame() {
        Application.Quit();
    }

    ///paused menu

    public void resume() {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

        BGM.volume = defaultVolume;

    }


    public void pauseGame() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        //quiet music
        BGM.volume = 0.1f;
    }

}
