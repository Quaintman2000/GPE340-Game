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
    public float attackRange = 3;
    public float attackAngle = 15;

    public float angleToPlayer;
    public float distanceToPlayer;
    public bool canAttack
    {
        get
        {
            float angleToTarget = Vector3.Angle(transform.forward, (followTarget.position - transform.position));
            return ((angleToTarget <= attackAngle) && Vector3.Distance(transform.position, followTarget.position) <= attackRange);
        }
    }
    public enum aIState{follow, attack };
    public aIState currentAIState = aIState.follow;

    Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        pawn = GetComponent<Pawn>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        nextDesisionTime = Time.time;

        followTarget = FindObjectOfType<Player>().transform;

        weapon = GetComponent<Pawn>().weapon;
    }

    // Update is called once per frame
    void Update()
    {
        angleToPlayer = Vector3.Angle(transform.forward, (followTarget.position - transform.position));
        distanceToPlayer = Vector3.Distance(transform.position, followTarget.position);

        if (canAttack)
        {
            currentAIState = aIState.attack;
            if(agent.enabled != false)
            {
                agent.enabled = false;
            }
            
        }
        else
        {
           currentAIState = aIState.follow;
            if (agent.enabled != true)
            {
                agent.enabled = true;
            }
            
        }

        if (currentAIState == aIState.follow)
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
        else if(currentAIState == aIState.attack)
        {
            weapon.OnTriggerPull();
          
        }

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

    protected void OnDrawGizmos()
    {
        Color canAttackColor = Color.green;
        Color cantAttackColor = Color.red;

        if(canAttack)
        {
            Gizmos.color = canAttackColor;
        }
        else
        {
            Gizmos.color = cantAttackColor;
        }
        Gizmos.DrawLine(transform.position, followTarget.position);


        
    }

}
