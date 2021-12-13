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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // Jump upwards when the player presses the space bar, but not after certain height
     if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < maxHeight)
        {
            rb.AddForce(Vector3.up * jumpForce, playerForce); // jump y
        }

        // Apply some artifical gravity to prevent exponential upwards movement
        rb.AddForce(Vector3.down * gravity, gravityForce); // push down y
    }
}
