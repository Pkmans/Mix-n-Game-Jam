using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject deadUI, scoreObject, hpBar, jetPackBar;
    private GameObject enemSpawner, itemSpawner;

    public scoreScript scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        //reference to spawners
        enemSpawner = GameObject.Find("enemySpawner");
        itemSpawner = GameObject.Find("itemSpawner");
    }

    public void onPlayerDeath() {
        deadUI.SetActive(true);

        hpBar.SetActive(false);
        jetPackBar.SetActive(false);

        enemSpawner.SetActive(false);
        itemSpawner.SetActive(false);
        
        //move score object
        moveScoreObject();
    }

    void moveScoreObject() {
        RectTransform rectTransform = scoreObject.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector3(-608, 265, 0);
        rectTransform.localScale = new Vector3(2.2f, 2.2f, 2.2f);
    }
}
