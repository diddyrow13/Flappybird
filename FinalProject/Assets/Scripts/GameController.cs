using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameController : MonoBehaviour
{

    private static GameController myGame; //Singleton HAS TO BE STATIC

    public UnityEvent gameOver;

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

        gameOver = new UnityEvent();
    }

}
