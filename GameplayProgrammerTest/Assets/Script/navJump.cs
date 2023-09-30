using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navJump : MonoBehaviour
{
    /*[Header("Jumping")]
    public float jumpSpeed = 2.0f;                   // how fast to move while jumping in the air
    private bool hasRoomToJump;                      // lets the AI know when it is able to jump (when it has room to jump)
    private Vector3 jumpLandPoint;                   // the landing point for jumping
    private Vector3 jumpStartPoint;                  // the start point for jumping
    private float startTime;                         // used in jump calulation
    private float jumpTimerReset;                    // used to calulate the jump
    private bool startJump;                          // let us know when to start jumping
    private bool endJump;                            // lets us know when the jump is suppose to end
    private bool jumpResetNavMesh;                   // lets us know when to turn the navmeshagent back on
    private Transform target;                        // the target we want the AI focus on
    public float distToTarget;                       // how far away is the target
    public bool testJump;                            // test weather the character can jump
    public GameObject TempCube;                      // a test cube to show where the character is going to jump
    public float testLenght;                         // how far we want to jump but need to test if there is open space first
    public bool showJumpArea;
    //SCRIPTS
    private NavMeshAgent agent;     // the navMeshAgent
    private UnityStandardAssets.Characters.ThirdPerson.AICharacterControl AI; // the AI controller
    private UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter character; //the character script


    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        AI = GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>();
        character = GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>();
    }

    public void GetTargetDist()
    {
        distToTarget = Vector3.Distance(transform.position, target.position);
    }

    void Update()
    {
        TestRoomForJump();
        target = AI.target;
        if (startJump)
        {
            HandleAirMovment();
        }
        if (testJump)
        {
            GetTargetDist();
            if (hasRoomToJump)
            {
                jumpSetUp();
                testJump = false;
            }
        }
    }

    public void jumpSetUp()
    {
        var lookPos = target.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 9999999);
        float jumpLenght;
        if (distToTarget < character.m_JumpPower)
        {
            jumpLenght = distToTarget + 1;
        }
        else
        {
            jumpLenght = character.m_JumpPower;
        }
        testLenght = jumpLenght;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(transform.position + transform.TransformDirection(new Vector3(0, 0, jumpLenght)), out hit, 7.0f, NavMesh.AllAreas))
        {
            if (agent.enabled)
            {
                agent.isStopped = true;

                agent.enabled = false;
            }
            jumpLandPoint = hit.position + new Vector3(0, 1, 0);
            if (showJumpArea)
            {
                Instantiate(TempCube, hit.position, Quaternion.identity);
            }
            Jump();
        }
    }


    public void Jump()
    {
        StartCoroutine(OffNavMesh());
        jumpStartPoint = transform.position;
        startJump = true;
        endJump = false;
    }

    public void OnCollisionEnter()
    {
        if (jumpResetNavMesh)
        {
            if (character.ShowGroundedStatus())
            {
                agent.enabled = true;
            }
            if (agent.isOnNavMesh)
            {
                jumpResetNavMesh = false;
            }
            else
            {
                jumpResetNavMesh = true;
                agent.enabled = false;
            }
        }
    }

    IEnumerator OffNavMesh()
    {
        yield return new WaitForSeconds(0.5f);
        agent.enabled = false;
    }

    IEnumerator RestartNavMesh()
    {
        yield return new WaitForSeconds(0.1f);
        if (character.ShowGroundedStatus())
        {
            agent.enabled = true;
        }
        else
        {
            jumpResetNavMesh = true;
        }
    }

    public void StopJump()
    {
        startJump = false;
        jumpTimerReset = 0;
        StartCoroutine(RestartNavMesh());
    }

    void HandleAirMovment()
    {
        // The center of the arc
        Vector3 center = (jumpStartPoint + jumpLandPoint) * 0.5F;
        // move the center a bit downwards to make the arc vertical
        center -= new Vector3(0, 1, 0);
        // Interpolate over the arc relative to center
        Vector3 riseRelCenter = jumpStartPoint - center;
        Vector3 setRelCenter = jumpLandPoint - center;
        // The fraction of the animation that has happened so far is
        // equal to the elapsed time divided by the desired time for
        // the total journey.
        float fracComplete = (jumpTimerReset - startTime) / jumpSpeed;
        jumpTimerReset += Time.deltaTime;
        transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        transform.position += center;
        float dist;
        dist = Vector3.Distance(transform.position, jumpLandPoint);
        if (dist < 0.5f)
        {
            jumpStartPoint = jumpLandPoint;
            endJump = true;
            StopJump();
            jumpTimerReset = 0;
        }
    }

    public void TestRoomForJump()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        var direction = Vector3.up;
        if (Physics.Raycast(transform.position + direction * testLenght + new Vector3(0, 0.5f, 0), fwd, out hit, testLenght, layerMask) || Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), direction, out hit, testLenght, layerMask))
        {
            Debug.DrawRay(transform.position + direction * testLenght + new Vector3(0, 0.5f, 0), fwd * testLenght, Color.red);
            Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), direction * testLenght, Color.red);
            hasRoomToJump = false;
        }
        else
        {
            Debug.DrawRay(transform.position + direction * testLenght + new Vector3(0, 0.5f, 0), fwd * testLenght, Color.green);
            Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), direction * testLenght, Color.green);
            hasRoomToJump = true;
        }
    }*/
}
