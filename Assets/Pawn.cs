﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    // Stores animator.
    private protected Animator anim;
    // Stores Speed and turn speed.
    [SerializeField] protected float speed = 5;
    [SerializeField] protected float turnSpeed = 180;
    // Stores Camera the player will be using.
    public Camera playerCamera;
    public Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void EquipWeapon(Weapon weapon)
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

    private void OnAnimatorIK(int layerIndex)
    {
        if(weapon != null)
        {
            anim.SetLookAtPosition(weapon.transform.position + weapon.transform.forward);
            if(weapon.rightHandPoint != null)
            {
                anim.SetIKPosition(AvatarIKGoal.RightHand, weapon.rightHandPoint.position);
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                anim.SetIKRotation(AvatarIKGoal.RightHand, weapon.rightHandPoint.rotation);
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            }
            else
            {
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            }

            if (weapon.leftHandPoint != null)
            {
                anim.SetIKPosition(AvatarIKGoal.LeftHand, weapon.leftHandPoint.position);
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                anim.SetIKRotation(AvatarIKGoal.LeftHand, weapon.leftHandPoint.rotation);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            }
            else
            {
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            }
        }
    }
}
