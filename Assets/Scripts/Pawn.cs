using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pawn : MonoBehaviour
{
    // Stores animator.
    private protected Animator anim;
    // Stores Speed and turn speed.

    [Header("Movement:"),SerializeField, Tooltip("The speed the player moves.")]
    public float speed = 5;
    [SerializeField, Tooltip("The speed the player turns.")] 
    protected float turnSpeed = 180;
    
    [Header("Weaponry:"), Tooltip("The weapon the pawn is currently using.")]
    public Weapon weapon;
    [Tooltip("The position the weapon instaniates at so the IK doesn't look as weird.")]
    public Transform gunHoldPoint;
    [SerializeField, Tooltip("The force applied when the user jumps.")]
    protected float jumpForce;

    public Rigidbody rgbd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// Instaniates the weapon at the gunHoldPosition to look as normal as possible.
    /// </summary>
    /// <param name="weaponToEquip">The weapon to spawn.</param>
    public void EquipWeapon(Weapon weaponToEquip)
    {
        if (weapon != null)
        {
            Destroy(weapon.gameObject);
        }
        weapon = Instantiate(weaponToEquip) as Weapon;
        weapon.transform.SetParent(this.gameObject.transform);
        weapon.transform.position = gunHoldPoint.position;
        weapon.transform.rotation = gunHoldPoint.rotation;
    }
    /// <summary>
    /// Rotates the object towards the look at point.
    /// </summary>
    /// <param name="lookAtPoint">The Vector3 Position to look at.</param>
    protected void RotateTowards(Vector3 lookAtPoint)
    {
        // Find the rotation to look at our look at point.
        Quaternion goalRotation;
        goalRotation = Quaternion.LookRotation(forward: (lookAtPoint - transform.position), upwards: Vector3.up);

        // Rotates a little bit towards our goal.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, goalRotation, turnSpeed * Time.deltaTime);
    }
    protected void SwingSword()
    {
        if(weapon.GetComponent<SwordWeapon>())
        {
            weapon.GetComponent<SwordWeapon>().isAttacking = !weapon.GetComponent<SwordWeapon>().isAttacking;
        }
    }
    protected void CastSpell()
    {
        if(weapon.GetComponent<MagicStaffWeapon>())
        {
            weapon.GetComponent<MagicStaffWeapon>().ShootProjectile();
        }
    }

    protected void Jump()
    {
        anim.applyRootMotion = false;

        Vector3 jumpDirection = new Vector3(x: 0, y: 1, z: 1).normalized;

        jumpDirection = transform.InverseTransformDirection(direction: jumpDirection);

        rgbd.AddForce(jumpDirection * jumpForce);
    }
    /// <summary>
    /// Activates all the IK for the joints.
    /// </summary>
    /// <param name="layerIndex"></param>
    private void OnAnimatorIK(int layerIndex)
    {
        if (weapon != null)
        {
            anim.SetLookAtPosition(weapon.transform.position + weapon.transform.forward);
            if (weapon.rightHandPoint != null)
            {
                anim.SetIKPosition(AvatarIKGoal.RightHand, weapon.rightHandPoint.position);
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                anim.SetIKRotation(AvatarIKGoal.RightHand, weapon.rightHandPoint.rotation);
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            }
            else
            {
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            }

            if (weapon.leftHandPoint != null)
            {
                anim.SetIKPosition(AvatarIKGoal.LeftHand, weapon.leftHandPoint.position);
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                anim.SetIKRotation(AvatarIKGoal.LeftHand, weapon.leftHandPoint.rotation);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            }
            else
            {
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            }
        }
    }
}
