using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    public int speed;
    //public Transform camReference;
    private Rigidbody rb;
    private float facing;
    private Animator anim;

    private NavMeshAgent _navMeshAgent;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        Vector3 movement = new Vector3((Input.GetAxis("Horizontal") * speed), 0, (Input.GetAxis("Vertical") * speed));
        //movement = camReference.TransformDirection(movement);
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        if (rb.velocity.x > 0 || rb.velocity.x <0 || rb.velocity.z > 0 || rb.velocity.z <0)
        {
            anim.SetBool("canWalk", true);

        }
        else if(rb.velocity.x ==0 || rb.velocity.z == 0 )
        {
            anim.SetBool("canWalk", false);

        }

        if (movement.x != 0 || movement.z != 0)
        {
            facing = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        }
        rb.rotation = Quaternion.Euler(0, facing, 0);
    }
    private void FixedUpdate()
    {
        //camReference.eulerAngles = new Vector3(0, camReference.eulerAngles.y, camReference.eulerAngles.z);
    }
}