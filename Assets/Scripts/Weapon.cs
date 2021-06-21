using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("IK Tools:")]
    // Stores the position of the left and right hand points of the weapon.
    [Tooltip("Store the right and left hand transforms here respectfully.")]
    public Transform rightHandPoint, leftHandPoint;
    // Stores damage value per round.
    [Header("Projectile Stats:"), SerializeField, Tooltip("The maximum damage per shot of the weapon.")]
    protected float damage;
    // Stores the projectile it shoots.
    [SerializeField, Tooltip("Projectile Fired")]
    protected Projectile projectile;
    // The firepoint position from which the projectile spawns at.
    [Tooltip("The position where the bullet spawns.")]
    public GameObject firepoint;
    // Stores the firetypes available.
    public enum FireType { singleFire, autoFire };
    // Stores the firetype chosen.
    [Header("Attack Mechanics:"), SerializeField,Tooltip("Select the fire type desired for the weapon. Auto Fire: Click and hold for continuous fire. Single Fire: Click once, shoot once.")]
    public FireType fireType;
    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {

    }
    /// <summary>
    /// When the trigger is pulled.
    /// </summary>
    public abstract void OnTriggerPull();
    /// <summary>
    /// When the trigger is released.
    /// </summary>
    public abstract void OntriggerRelease();
    /// <summary>
    /// When the trigger is being held.
    /// </summary>
    public abstract void OnTriggerHold();
    /// <summary>
    /// Shoots the projectile.
    /// </summary>
    public abstract void ShootProjectile();
}
