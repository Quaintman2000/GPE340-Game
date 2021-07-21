using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Pawn
{
    // Helps keep track of our grounded.
    [SerializeField]
    Transform groundPoint;
    [SerializeField] GameObject swordObject;
    [SerializeField] GameObject staffObject;
    // Stores Camera the player will be using.
    [Tooltip("Store the camera in the scene here.")]
    public Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        // Grabs the animator component needed for the animations.
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handles the basic movement of the character
        MovementHandler();

        // You press down on the spacebar.
        if (Input.GetKeyDown(key: KeyCode.Space))
        {
            // Sets IsGrounded to false, causing the jumping animation.
            anim.SetBool("IsGrounded", false);
        }
        else
        {
            // If you don't press the space bar, send raycasts to see if you're on the ground or not.
            anim.SetBool("IsGrounded", Physics.Raycast(groundPoint.position, Vector3.down, 0.5f));
        }

        // If you press down the left control.
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetBool("IsCrouching", !(anim.GetBool("IsCrouching")));
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            swordObject.SetActive(true);
            staffObject.SetActive(false);
            weapon = swordObject.GetComponent<Weapon>();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            swordObject.SetActive(false);
            staffObject.SetActive(true);
            weapon = staffObject.GetComponent<Weapon>();
        }
        if(weapon.fireType == Weapon.FireType.autoFire)
        {
            if (Input.GetButton("Fire1"))
            {
                weapon.OnTriggerHold();
            }
        }
        if (weapon.fireType == Weapon.FireType.singleFire)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                weapon.OnTriggerPull();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                weapon.OntriggerRelease();
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            //Todo alt fire

        }
    }
    /// <summary>
    /// Takes care of the movement system for the player. Grabs vertical and horizontal input as well as the mouse position for needed values of the blend tree.
    /// </summary>
    private void MovementHandler()
    {
        // Grabs the direction for the player's joystick.
        Vector3 stickDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Max's the magnitude of the vector to 1.
        stickDirection = Vector3.ClampMagnitude(stickDirection, 1);
        // Converts the vector to local space.
        Vector3 animationDirection = transform.InverseTransformDirection(stickDirection);
        // Debug.Log("animation Direction: " + animationDirection);
        // Sets the floats for the animator.
        anim.SetFloat("Forward", animationDirection.z * speed);
        anim.SetFloat("Right", animationDirection.x * speed);


        // Rotate player to the mouse pointer.
        RotateToMousePointer();
    }
    /// <summary>
    /// Rotate's the player towards the mouse.
    /// </summary>
    public void RotateToMousePointer()
    {
        // Find the plane the character is standing on.
        Plane groundPlane = new Plane(Vector3.up, transform.position);

        // Draw a ray from the mousepointer on the screen towards the plane we are standing on.
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        // Using the distance to the intersection of plane and ray, find the point in World Space.
        float distance;
        groundPlane.Raycast(ray: ray, out distance);
        Vector3 targetPoint = ray.GetPoint(distance);

        // Rotate towards that point.
        RotateTowards(targetPoint);
    }


}
