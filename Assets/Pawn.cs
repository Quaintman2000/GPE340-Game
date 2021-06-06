using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    private protected Animator anim;
    [SerializeField] protected float speed = 5;
    [SerializeField] protected float turnSpeed = 180;
    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    /// <summary>
    /// Rotates the object towards the look at point.
    /// </summary>
    /// <param name="lookAtPoint">The Vector3 Position to look at.</param>
    protected void RotateTowards(Vector3 lookAtPoint)
    {
        // Find the rotation to look at our look at point.
        Quaternion goalRotation;
        goalRotation = Quaternion.LookRotation(forward: (lookAtPoint - transform.position), upwards: Vector3.up);

        // Rotates a little bit towards our goal.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, goalRotation, turnSpeed * Time.deltaTime);
    }
}
