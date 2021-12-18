using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;

    public float jumpForce;
    public ForceMode playerForce;
    public float gravity;
    public ForceMode gravityForce;

    private float maxHeight = 18.5f; //how high player can go (dependant on camera)

    private bool isAlive = true;

    private Transform boximon;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameController.Instance.gameOver.AddListener(onDeath); // Sub to event
        boximon = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        // Apply some artifical gravity to prevent exponential upwards movement
        rb.AddForce(Vector3.down * gravity, gravityForce); // push down y

        // See if player is alive
        if (!isAlive)
            return;

        // Jump upwards when the player presses the space bar, but not after certain height
     if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < maxHeight)
        {
            rb.AddForce(Vector3.up * jumpForce, playerForce); // jump y
        }
    }


    //Rotate the player up and down when jumping not jumping
    private void FixedUpdate()
    {
        if (rb.velocity.y > 0) // Player moving up roatte up
        {
            boximon.rotation = Quaternion.Lerp(boximon.rotation, Quaternion.Euler(0, 108, 0), 0.2f);
        }
        else // Player is falling so rotate DOWN
        {
            boximon.rotation = Quaternion.Lerp(boximon.rotation, Quaternion.Euler(60, 108, 0), 0.2f);
        }
    }

    private void onDeath()
    {
        isAlive = false;
    }
}
