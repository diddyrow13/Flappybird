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

    private void OnCollisionEnter(Collision collision)
    {
        // See if obj is player
        if (collision.collider.CompareTag("Player"))
        {
            // Game Over
            GameController.Instance.gameOver.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Increase score
            GameController.Instance.UpdateScore(1); // Increases score by 1
        }
    }
}
