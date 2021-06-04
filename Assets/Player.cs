using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Pawn
{
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Grabs the direction for the player's joystick.
        Vector3 stickDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // Max's the magnitude of the vector to 1.
        stickDirection = Vector3.ClampMagnitude(stickDirection, 1);
        // Converts the vector to local space.
        Vector3 animationDirection = transform.InverseTransformDirection(stickDirection);

        // Sets the floats for the animator.
        anim.SetFloat("Forward", animationDirection.y * speed);
        anim.SetFloat("Right", animationDirection.x * speed);

        // Rotate player to the mouse pointer
        RotateToMousePointer();
    }

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
