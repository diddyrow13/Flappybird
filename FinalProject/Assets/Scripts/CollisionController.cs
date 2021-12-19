using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
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

        if (gameObject.CompareTag("Bonus"))
        {
            // Despawn bonus object
            gameObject.SetActive(false);

            // Increase score
            GameController.Instance.UpdateScore(5); // Increases score by 1
        }
    }
}
