using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public class PlayerJump : MonoBehaviour
{
    public int jumpForce;
    private bool canJump;
    //private NavMeshAgent agent;
    public LayerMask groundLayer;
    public Transform groundCheck;
    private Rigidbody rb;

    //[SerializeField] private GameObject cube;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            Jump();
        }

        bool grounded = Physics.Linecast(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), groundCheck.position, groundLayer);
        Debug.DrawLine(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), groundCheck.position, Color.red);

        if (grounded == true)
        {
            canJump = true;
            //agent.enabled = false;
        }
        else
        {
            canJump = false;
            //agent.enabled = true;
        }

        //if (Input.GetButtonDown("Fire2"))
        //{
        //    cube.transform.parent = null;
        //    cube.GetComponent<Rigidbody>().useGravity = true;
        //    cube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //    cube.GetComponent<BoxCollider>().enabled = true;
        //}
    }

    private void Jump()
    {
        canJump = false;
        rb.AddForce(Vector3.up * jumpForce);
    }
}