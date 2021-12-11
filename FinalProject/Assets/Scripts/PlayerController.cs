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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Jump upwards when the player presses the space bar
     if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, playerForce);
        }

        // Apply some artifical gravity to prevent exponential upwards movement
        rb.AddForce(Vector3.down * gravity, gravityForce);
    }
}
