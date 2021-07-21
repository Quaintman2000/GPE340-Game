using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStaffWeapon : Weapon
{
    // Stores fire rate.
    [Header("Gun Mechanics:"), SerializeField, Range(0.0001f, 90000), Tooltip("The maximum fire rate of the weapon. Rounds per Minute")]
    private float fireRate;

    // Stores the timer.
    float timer;
    // Determines if the gun can shoot.
    public bool canShoot
    {
        get { return (timer <= 0); }
    }
   [SerializeField] Animator anim;
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Reduces the timer over time so you can keep shooting.
        timer -= Time.deltaTime;
    }
}
