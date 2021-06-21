using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Pickup
{
    public Weapon weapon;
    public override void ApplyEffect(Pawn pawn)
    {
        pawn.EquipWeapon(weapon);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered " + this.gameObject.name);
        if (other.gameObject.GetComponent<Pawn>() != null)
        {
            Debug.Log("step 2 worked");
            ApplyEffect(other.gameObject.GetComponent<Pawn>());

        }
    }
}
