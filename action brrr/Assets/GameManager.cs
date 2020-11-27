using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject deadUI, scoreObject, hpBar, jetPackBar;
    private GameObject enemSpawner, itemSpawner;

    public scoreScript scoreScript;

    //ref to player
    [HideInInspector]
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        //reference to spawners
        enemSpawner = GameObject.Find("enemySpawner");
        itemSpawner = GameObject.Find("itemSpawner");
    }

    void Update() {
        player = GameObject.Find("Player");
    }

    public void onPlayerDeath() {
        setUI();

        Destroy(player);

        //move score object
        moveScoreObject();
    }

    void moveScoreObject() {
        RectTransform rectTransform = scoreObject.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector3(-608, 265, 0);
        rectTransform.localScale = new Vector3(2.2f, 2.2f, 2.2f);
    }

    void setUI() {
        deadUI.SetActive(true);

        hpBar.SetActive(false);
        jetPackBar.SetActive(false);

        enemSpawner.SetActive(false);
        itemSpawner.SetActive(false);
    }
}
