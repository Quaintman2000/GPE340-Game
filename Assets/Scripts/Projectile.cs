using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Stores the amount of force applied to the bullet when it fires.
    [Header("Projectile Stats:"), SerializeField, Tooltip("The amount of force applied to the bullet when it fires."), Range(100, 2000)]
    private float projectileForce;
    // Start is called before the first frame update
    [SerializeField, Tooltip("How long the projectile lasts in the scene in seconds."), Range(0, 20)]
    float lifeSpan;
    // Stores amount of damage the projectile deals.
    public float damage;

    void Start()
    {
        // Grabs the rigid body.
        Rigidbody rigidbody = this.gameObject.GetComponent<Rigidbody>();
        // Applys set forward force to the projectile.
        rigidbody.AddForce(transform.forward * projectileForce);
        // Destoy the bullet after set lifespan time in case it never hits something.
        Destroy(this.gameObject, lifeSpan);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit " + other.gameObject.name);
        // If it hits anything else with a health bar
        if (other.gameObject.GetComponentInParent<Health>() != null)
        {
            Debug.Log(other.gameObject.name + "has a health");
            // Subtract their health from damage.
            other.gameObject.GetComponentInParent<Health>().TakeDamage(damage);

        }
        // destroys the bullet after it hits something and applies it effects.
        Destroy(this.gameObject);

    }

}
