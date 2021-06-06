using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    // Needed variables.
    public Transform playerToFollow;
    [SerializeField]
    protected Vector3 cameraOffset;
    [SerializeField]
    protected float cameraSpeed;
    // Update is called once per frame
    void Update()
    {
        // Follow the player with the offset.
        MoveWithPlayer();
    }

    /// <summary>
    /// Moves the camera's position along with the player
    /// </summary>
    void MoveWithPlayer()
    {
        // Create a vector for position to be at.
        Vector3 positionToBe;
        // Calaculate position to be at from player's position + offset;
        positionToBe = playerToFollow.position + cameraOffset;
        // Move towards that position.
       transform.position = Vector3.MoveTowards(transform.position, positionToBe, cameraSpeed * Time.deltaTime);
    }
}
