using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    /// <summary>
    /// Applies the set effect to the pawn.
    /// </summary>
    /// <param name="pawn">The pawn applied to.</param>
    public virtual void ApplyEffect(Pawn pawn)
    {
        // Destroys the pawn.
        Destroy(this.gameObject);
    }

 

}
