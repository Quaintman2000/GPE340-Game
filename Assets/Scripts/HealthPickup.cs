using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    // Stores how much health the pickup heals.
    [SerializeField, Tooltip("The amount of health this pick up heals. Defaults to ten.")]
    float healValue = 10;
    /// <summary>
    /// Heals the pawn with set heal value.
    /// </summary>
    /// <param name="pawn">The pawn healed.</param>
    public override void ApplyEffect(Pawn pawn)
    {
        // Grabs the pawn's health componet and heals them.
        pawn.gameObject.GetComponent<Health>().Heal(10);
        base.ApplyEffect(pawn);
    }
    // When a collider triggers the pickup.
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered " + this.gameObject.name);
        // If the collider has a pawn componet.
        if (other.gameObject.GetComponent<Pawn>() != null)
        {
            Debug.Log("step 2 worked");
            // Apply the effect to the pawn.
            ApplyEffect(other.gameObject.GetComponent<Pawn>());

        }
    }
}
