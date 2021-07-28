using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    Animator anim;
    Collider topCollider;
    Rigidbody topRigidbody;
    List<Rigidbody> ragdollRigidbodies;
    List<Collider> ragdollColliders;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        topCollider = GetComponent<Collider>();
        topRigidbody = GetComponent<Rigidbody>();

        ragdollColliders = new List<Collider>(GetComponentsInChildren<Collider>());
        ragdollRigidbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            StartRagdoll();
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            StopRagdoll();
        }
    }

    public void StartRagdoll()
    {
        // Turon off the anim.
        anim.enabled = false;
        // Turn on the ragdoll colliders.
        foreach(Collider currentCollider in ragdollColliders)
        {
            currentCollider.enabled = true;
        }
        // Turn on the ragdoll rigidbodies.
        foreach(Rigidbody currentRigidBody in ragdollRigidbodies)
        {
            currentRigidBody.isKinematic = false;
        }
        // Turn off the Big Capsule collider.
        topCollider.enabled = false;
        // Turn off the Big rigidbody.
        topRigidbody.isKinematic = true;

    }
    public void StopRagdoll()
    {
        // Turn on the anim.
        anim.enabled = true;
        // Turn off the ragdoll colliders.
        foreach (Collider currentCollider in ragdollColliders)
        {
            currentCollider.enabled = false;
        }
        // Turn off the ragdoll rigidbodies.
        foreach (Rigidbody currentRigidBody in ragdollRigidbodies)
        {
            currentRigidBody.isKinematic = true;
        }
        // Turn on the Big Capsule collider.
        topCollider.enabled = true;
        // Turn on the Big rigidbody.
        topRigidbody.isKinematic = false;

    }
}
