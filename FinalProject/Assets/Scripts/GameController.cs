using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameController : MonoBehaviour
{
    /*
     * POINT OF SCRIPT
     * ---------------------
     * Have a single instance of the game (singleton)
     * Use unity events to 
     * Save the score if its a new high score
     * Update the score when player does collect bonus or goest through tube trigger
     * Change the background music when player dies/ is alive
     */

    private static GameController myGame; //Singleton HAS TO BE STATIC

    public UnityEvent gameOver;

    private int score = 0;
    private int highScore = 0; // Defualt

    public UnityEvent<int> scoreUpdate;

    public AudioClip backgroundMusic;
    public AudioClip gameoverMusic;
    private AudioController audiocontroller;

    public int HighScore // TODO CHECK FOR RACE CONDITION TODO
    {
        get
        {
            if (score > highScore)
                return score;
            return highScore;
        }
    }

    //HAS TO BE STATIC ref class not inst
    public static GameController Instance
    {
        get
        {
            //see if there is an instance already
            if (myGame == null)
            {
                myGame = GameObject.FindObjectOfType<GameController>();

                // Create instance since null still
                if (myGame == null)
                {
                    var newInst = new GameObject();
                    myGame = newInst.AddComponent<GameController>();
                }
            }
            return myGame;
        }
    }


    // Makes sure instance doesn't get created multiple times
    private void Awake()
    {
        //Create instance if none exists
        if (myGame == null)
        {
            myGame = this;
        }

        //If not the right instance, destroy
        if (myGame != this)
        {
            Destroy(this.gameObject); // Free memory
        }

        audiocontroller = FindObjectOfType<AudioController>();
        audiocontroller.ChangeMusic(backgroundMusic);

        gameOver    = new UnityEvent();         //Create game over event
        scoreUpdate = new UnityEvent<int>();    //Create score update event

        highScore = SaveSystem.LoadScore();     // Get the high score
        gameOver.AddListener(onPlayerDeath);    // 
    }

    private void onPlayerDeath()
    {
        audiocontroller.ChangeMusic(gameoverMusic);
        // Save high score if its higher than current high score
        if (score > highScore)
        {
            SaveSystem.saveScore(score);
        }
    }

    // Update the score when the player does something (go through tube or bonus)
    public void UpdateScore(int org)
    {
        score += org;
        scoreUpdate.Invoke(score);
    }
}
