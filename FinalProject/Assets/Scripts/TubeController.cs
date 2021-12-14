using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeController : MonoBehaviour
{

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

    private void onDeath()
    {
        speed = 0f; // Stops the tunnels (on player death)
    }
}
