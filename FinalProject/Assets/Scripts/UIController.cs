using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

    /*
     * POINT OF SCRIPT
     * ---------------------
     * Display the score during game
     * Display a game over screen that has the current score and high score
     * Have a retry button that reloads the scene
     * 
     */

    public TextMeshProUGUI scoreText;

    public GameObject endScreen;

    public TextMeshProUGUI highScoreText;

    public TextMeshProUGUI endScoretext;


    //Set the score on the screen after update
    private void scoreUpdate(int score)
    {
        scoreText.text = score.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.scoreUpdate.AddListener(scoreUpdate); //Sub to score update event
        GameController.Instance.gameOver.AddListener(onPlayerDeath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onPlayerDeath()
    {
        highScoreText.text = GameController.Instance.HighScore.ToString(); // Grab the high score
        endScoretext.text = scoreText.text; // Set end score text
        scoreText.enabled = false; // Hide prev score
        endScreen.SetActive(true); // Change to end screen

    }

    //Reload the scene
    public void Respawn()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
