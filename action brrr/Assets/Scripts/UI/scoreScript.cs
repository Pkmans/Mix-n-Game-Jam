using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class scoreScript : MonoBehaviour
{
    [HideInInspector]
    public int scoreValue, highScore;

    private TextMeshProUGUI score;
    public GameObject highscoreObject;
    private TextMeshProUGUI highscore;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
        highscore = highscoreObject.GetComponent<TextMeshProUGUI>();
        anim = GetComponent<Animator>();

        score.text = "0";
        highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int scoreVal) {
        anim.SetTrigger("add");

        scoreValue += scoreVal;
        score.text = scoreValue.ToString();

        if (scoreValue > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", scoreValue);
            highscore.text = scoreValue.ToString();
        }
    }



}
