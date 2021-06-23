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
    // Start is called before the first frame update
    void Start()
    {
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

    }

    private void OnAnimatorMove()
    {
        agent.velocity = animator.velocity;
    }
}
