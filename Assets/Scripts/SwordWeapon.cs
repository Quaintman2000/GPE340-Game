using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : Weapon
{
    // Stores the animator.
    [SerializeField, Tooltip("Place the player animator here.")]
    Animator anim;
    public override void ShootProjectile()
    {
        throw new System.NotImplementedException();
    }
    public override void OnTriggerHold()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerPull()
    {
        anim.SetTrigger("SlashTrigger");
    }

    public override void OntriggerRelease()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Health>() != null)
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
