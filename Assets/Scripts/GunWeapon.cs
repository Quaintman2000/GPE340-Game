using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : Weapon
{
    [SerializeField]
    [Range(0.0001f, 90000)]
    [Tooltip("The maximum fire rate of the weapon.")]
    private float fireRate;
    [SerializeField]
    [Tooltip("The maximum damage per shot of the weapon.")]
    private float damage;

    [SerializeField]
    GameObject projectile;

    public GameObject firepoint;

    
 


    float timer;
    [SerializeField]
   public bool canShoot 
    { 
        get { return (timer <= 0); }
        set { canShoot = value; }
    }

    public override void ShootProjectile()
    {
        Debug.Log("Bang");
        GameObject newProjectile = Instantiate(projectile,firepoint.transform.position,firepoint.transform.rotation);
        
    }
    public override void OnTriggerHold()
    {
        if (canShoot)
        {
            ShootProjectile();
            timer = (fireRate / (60*60));
           
        }
      
    }

    public override void OnTriggerPull()
    {
        if (canShoot)
        {
            ShootProjectile();
            

        }
    }

    public override void OntriggerRelease()
    {
        timer = (fireRate / (60 * 60));
    }

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;


    }
}
