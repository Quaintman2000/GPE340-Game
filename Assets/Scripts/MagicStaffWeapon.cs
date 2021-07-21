using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStaffWeapon : Weapon
{
    Animator anim;
    public override void OnTriggerHold()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerPull()
    {
        anim.SetTrigger("CastSpell");
    }

    public override void OntriggerRelease()
    {
        throw new System.NotImplementedException();
    }

    public override void ShootProjectile()
    {
        // Spawns the projectile at the firepoint position and rotation.
        Projectile newProjectile = Instantiate(projectile, firepoint.transform.position, firepoint.transform.rotation) as Projectile;
        // Set's the bullet's damage to be the gun's damage.
        newProjectile.damage = damage;
    }

   
}
