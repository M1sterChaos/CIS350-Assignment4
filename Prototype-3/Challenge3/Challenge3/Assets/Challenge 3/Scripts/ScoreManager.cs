/*
 * (Austin Buck)
 * (Assignment 4)
 * (Controls score and restarting game)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score;

    public bool won = false;

    private PlayerControllerX pcx;
    // Start is called before the first frame update
    void Start()
    {
        pcx = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if(score >= 1)
        {
            pcx.gameOver = true;
            won = true;
        }
        if(pcx.gameOver)
        {
            scoreText.text = "You Lose. \n Press R to Restart";
            if (won)
            {
                scoreText.text = "You Win. \n Press R to Restart";
            }
        }
        
        if((pcx.gameOver || won) && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
