using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileForce;
    // Start is called before the first frame update
    [SerializeField]
    [Tooltip("How long the projectile lasts in the scene in seconds.")]
    [Range(0, 20)]
    float lifeSpan;

    public GameObject shooter;
    public float damage;

    void Start()
    {
        Rigidbody rigidbody = this.gameObject.GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * projectileForce);
        Destroy(this.gameObject, lifeSpan);
    }

    private void OnTriggerEnter(Collider other)
    {
        // If hit the shooter.
        if(other.gameObject == shooter)
        {
            // Do nothing.
        }
        // If it hits anything else with a health bar
        else if(other.gameObject.GetComponent<Health>() != null)
        {
            // Subtract their health from damage.
        }
        // Hits anything else.
        else
        {
            Destroy(this.gameObject);
        }
    }

}
