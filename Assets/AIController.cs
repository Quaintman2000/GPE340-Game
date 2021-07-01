using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform followTarget;
    public float decisionDelay = 1;
    float nextDesisionTime;
    Animator animator;
    Pawn pawn;
    // Start is called before the first frame update
    void Start()
    {
        pawn = GetComponent<Pawn>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        nextDesisionTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextDesisionTime)
        {
            agent.SetDestination(followTarget.position);
            nextDesisionTime = Time.time + decisionDelay;
        }

        // Get the desired movement from the agent.
        Vector3 desiredMovement = agent.desiredVelocity;
        // Invert it
        desiredMovement = this.transform.InverseTransformDirection(desiredMovement);
        // Remove the speed by normailizing it to 1
        desiredMovement = desiredMovement.normalized;
        // Add the pawn speed.
        desiredMovement *= pawn.speed;
        // Pass into our root motion animator.
        animator.SetFloat("Forward", desiredMovement.z);
        animator.SetFloat("Right", desiredMovement.x);
    }

    public Transform GetNearestPlayerTransform()
    {
        Player[] players = FindObjectsOfType<Player>();
        // Stores the target transform
        Transform target = players[0].transform;
        // find and store distance to pawn
        float closestDistanceToPawn = Vector3.Distance(pawn.transform.position, target.position);

        foreach(Player player in players)
        {
            float distanceToPawn = Vector3.Distance(this.transform.position, player.transform.position);
            if(distanceToPawn <= closestDistanceToPawn)
            {
                target = player.transform;
                closestDistanceToPawn = distanceToPawn;
            }
        }

        return target;
    }
    private void OnAnimatorMove()
    {
        agent.velocity = animator.velocity;
    }

}
