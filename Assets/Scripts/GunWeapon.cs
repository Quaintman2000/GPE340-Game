using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : Weapon
{
    // Stores fire rate.
    [SerializeField, Range(0.0001f, 90000),Tooltip("The maximum fire rate of the weapon. Rounds per Minute")]
    private float fireRate;
    // Stores damage value per round.
    [SerializeField, Tooltip("The maximum damage per shot of the weapon.")]
    private float damage;
    // Stores the projectile it shoots.
    [SerializeField]
    Projectile projectile;
    // The firepoint position from which the projectile spawns at.
    public GameObject firepoint;
    // Stores the timer.
    float timer;
   // Determines if the gun can shoot.
   public bool canShoot 
    { 
        get { return (timer <= 0); }
        set { canShoot = value; }
    }
    // Shoots the projectile.
    public override void ShootProjectile()
    {
        Debug.Log("Bang");
        // Spawns the projectile at the firepoint position and rotation.
        Projectile newProjectile = Instantiate(projectile,firepoint.transform.position,firepoint.transform.rotation) as Projectile;
        // Set's the bullet's damage to be the gun's damage.
        newProjectile.damage = damage;
    }
    // When the trigger is being held.
    public override void OnTriggerHold()
    {
        // If I can shoot.
        if (canShoot)
        {
            // Shoot the projectile.
            ShootProjectile();
            // Set timer between shots.
            timer = (fireRate / (60*60));
           
        }
      
    }

    public override void OnTriggerPull()
    {
        // If I can shoot.
        if (canShoot)
        {
            // Shoot the projectile.
            ShootProjectile();
        }
    }

    public override void OntriggerRelease()
    {
        // Set timer between shots.
        timer = (fireRate / (60 * 60));
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set canShoot to true so you can shoot as soon as you get it.
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Reduces the timer over time so you can keep shooting.
        timer -= Time.deltaTime;
    }
}
