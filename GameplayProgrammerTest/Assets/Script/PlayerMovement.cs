using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    // How fast the Player will move
    [SerializeField] private float playerSpeed;

    // This should be an empty child of the camera, and is the Transform we will be using to update our Player's directional movement
    [SerializeField] private Transform cameraReference;

    // The Player's Rigidbody Component
    private Rigidbody rb;

    // The value we will be using to determine which direction the player faces while moving
    private float facing;

    private Animator anim;


    // Start is called before the first frame update
    private void Start()
    {
        // Sets the rotation of the empty child on our camera to match the camera's upon starting the game
        cameraReference.eulerAngles = new Vector3(0, 0, 0);

        // Directly grabs the Player's Rigidbody Component
        rb = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {
        // Creates float values out of our inputs multiplied by the amount of speed we set
        float xMovement = Input.GetAxis("Horizontal") * playerSpeed;
        float zMovement = Input.GetAxis("Vertical") * playerSpeed;

        // Vector3 values made up of our input values
        Vector3 movement = new Vector3(xMovement, 0, zMovement);
        // Vector3 movement = new Vector3((Input.GetAxis("Horizontal") * playerSpeed), 0, (Input.GetAxis("Vertical") * playerSpeed));

        movement = cameraReference.TransformDirection(movement);

        // Generates movement in the Player's Rigidbody using the Vector3 values from above
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);


       
        if (rb.velocity.x > 0 || rb.velocity.x < 0 || rb.velocity.z > 0 || rb.velocity.z < 0)
        {
            anim.SetBool("canWalk", true);

        }
        else if (rb.velocity.x == 0 || rb.velocity.z == 0)
        {
            anim.SetBool("canWalk", false);

        }

        if (movement.x != 0 || movement.z != 0)
        {
            // Takes our player's movement to calculate which angle our player should be rotating towards
            facing = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        }

        // Rotates our player to face in the direction it is moving towards
        rb.rotation = Quaternion.Euler(0, facing, 0);
    }

    private void FixedUpdate()
    {
        // Locks our camera reference's Transform to 0 
        cameraReference.eulerAngles = new Vector3(0, cameraReference.eulerAngles.y, 0);
    }

}
