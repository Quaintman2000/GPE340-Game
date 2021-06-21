using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Pickup
{
    // Stores the weapon the player picks up.
    [Tooltip("The weapon the pawn equips.")]
    public Weapon weapon;
    /// <summary>
    /// Equips the weapon set to the pawn.
    /// </summary>
    /// <param name="pawn">The pawn being applied.</param>
    public override void ApplyEffect(Pawn pawn)
    {
        // Makes the player equip the weapon.
        pawn.EquipWeapon(weapon);
        // Applies the rest of the effect.
        base.ApplyEffect(pawn);
    }

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
