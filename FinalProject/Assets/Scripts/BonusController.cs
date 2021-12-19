using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{

    /*
     * POINT OF SCRIPT
     * ---------------------
     * Controls the movement of the bonus sphere (direction and speed)
     * Also stops the movement of bonus spheres that are on spawned
     */

    [SerializeField] private float speed = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.gameOver.AddListener(onDeath); //sub to death event
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * (speed * Time.deltaTime);
    }


    // Freezes the bonus' that are on screen
    private void onDeath()
    {
        speed = 0f; // Stops the tunnels (on player death)
    }
}
