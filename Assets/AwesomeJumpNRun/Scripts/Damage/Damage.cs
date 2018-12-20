using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : AbstractDamage {
    private void OnCollisionEnter(Collision obj)
    {
        var healthOther = obj.collider.GetComponentInChildren<Health>();
        if (healthOther != null)
        {
            healthOther.TakeDamage(DamageAmount, DamageType);
            Debug.Log("did Damage");
            Debug.Log("Collided With" + obj.collider.name);
        }
    }
}
