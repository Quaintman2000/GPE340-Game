using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float speed;

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
    }
}
