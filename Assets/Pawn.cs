using System.Collections;
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
       if(Input.GetButtonDown("Fire1"))
        {
            weapon.OnTriggerPull();
        }
       if(Input.GetButtonUp("Fire1"))
        {
            weapon.OntriggerRelease();
        }
       if(Input.GetButtonDown("Fire2"))
        {
            //Todo alt fire
            
        }
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
}
