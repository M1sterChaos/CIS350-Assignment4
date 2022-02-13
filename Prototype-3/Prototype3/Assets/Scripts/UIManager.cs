/*
 * (Austin Buck)
 * (Assignment 4)
 * (Controls when the player wins or loses)
 */
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    private PlayerController pc;

    public bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if(!pc.gameOver)
        {
            scoreText.text = "Score: " + score;
        }
        if(pc.gameOver && !won)
        {
            scoreText.text = "You Lose!" + "\n" + "Press R to Try Again!";
        }
        if(score >= 10)
        {
            pc.gameOver = true;
            won = true;

            scoreText.text = scoreText.text = "You Win!" + "\n" + "Press R to Try Again!";
        }
        if(pc.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
