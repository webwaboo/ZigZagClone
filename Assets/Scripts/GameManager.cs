using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score;
    public Text scoreText;
    public Text highscoreText;
   
    public void Awake()
    {
        highscoreText.text = "Best: " + getHighscore().ToString();
    }


    //change status of game to started
    public void StartGame()
    {
        gameStarted = true; 
        FindObjectOfType<Road>().StartBuilding();
    }

    //load back 1st scene
    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    //change status of game to Started when Enter is pressed
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)) {
            StartGame();
        }
    }

    //incremente score
    public void IncreaseScore ()
    {
        score++;
        //text of score = score converted to string
        scoreText.text = score.ToString();
        //check if score is higher than highscore and set it in PlayerPrefs
        if(score > getHighscore())
        {
            PlayerPrefs.SetInt("Highscore", score);
            //text of score = new score converted to string
            highscoreText.text = "Best: " + score.ToString();
        }
        
    }

    //get highscore from player prefs
    public int getHighscore () 
    {
        int i = PlayerPrefs.GetInt("Highscore");
        return i;
    }
}
