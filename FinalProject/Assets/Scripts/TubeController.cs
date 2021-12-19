using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeController : MonoBehaviour
{
    /*
     * POINT OF SCRIPT
     * ---------------------
     * Controls the movement of the tubes (and score trigger) (direction and speed)
     * as well as stopping on game over
     */

    public float speed;

    private void Start()
    {
        GameController.Instance.gameOver.AddListener(onDeath); //sub to death event
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * (speed * Time.deltaTime);
    }

    // Freezes the tubes that are on screen
    private void onDeath()
    {
        speed = 0f; // Stops the tunnels (on player death)
    }
}
