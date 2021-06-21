using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public bool isTriggerPulled = false;
    public Transform rightHandPoint, leftHandPoint;

    public enum FireType { singleFire, autoFire };
    [SerializeField]
    public FireType fireType;
    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public abstract void OnTriggerPull();
    public abstract void OntriggerRelease();
    public abstract void OnTriggerHold();

    public abstract void ShootProjectile();
}
