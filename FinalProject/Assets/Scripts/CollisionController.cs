using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{

    /*
     * POINT OF SCRIPT
     * ---------------------
     * Controls what happens when certain objects collide
     *      oncollisionenter when player hits tube -> End the game
     *      ontriggerenter 
     *          when player passes through score trigger -> score +1
     *          when player passes through bonus sphere  -> score +5
     * 
     */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Seeing if the player has hit the ground or tubes
    private void OnCollisionEnter(Collision collision)
    {
        // See if obj is player
        if (collision.collider.CompareTag("Player"))
        {
            // Game Over
            GameController.Instance.gameOver.Invoke();
        }
    }

    //Seeing if the player has passed the score trigger plane
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !gameObject.CompareTag("Bonus"))
        {
            // Increase score
            GameController.Instance.UpdateScore(1); // Increases score by 1
        }

        if (other.CompareTag("Player") && gameObject.CompareTag("Bonus"))
        {
            // Despawn bonus object
            gameObject.SetActive(false);

            // Increase score
            GameController.Instance.UpdateScore(5); // Increases score by 1
        }
    }
}
