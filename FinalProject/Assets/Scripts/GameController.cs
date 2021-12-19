using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameController : MonoBehaviour
{

    private static GameController myGame; //Singleton HAS TO BE STATIC

    public UnityEvent gameOver;

    private int score = 0;
    private int highScore = 0; // Defualt

    public UnityEvent<int> scoreUpdate;

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
        if (myGame == null)
        {
            myGame = this;
        }

        //If not the right instance, destroy
        if (myGame != this)
        {
            Destroy(this.gameObject);
        }

        gameOver    = new UnityEvent();         //Create game over event
        scoreUpdate = new UnityEvent<int>();    //Create score update event

        highScore = SaveSystem.LoadScore();
        gameOver.AddListener(onPlayerDeath);
    }

    private void onPlayerDeath()
    {
        // Save high score if its higher than current high score
        if (score > highScore)
        {
            SaveSystem.saveScore(score);
        }
    }

    // Update the score when the player 
    public void UpdateScore(int org)
    {
        score += org;
        scoreUpdate.Invoke(score);
    }
}
