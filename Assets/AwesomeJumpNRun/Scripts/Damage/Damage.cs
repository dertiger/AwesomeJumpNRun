using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    [SerializeField] private int damageAmount;
    [SerializeField] private DamageType damageType;

    public int DamageAmount
    {
        get
        {
            return damageAmount;
        }
        private set
        {
            damageAmount = value;
        }
    }

    private void OnCollisionEnter(Collision obj)
    {
        var healthOther = obj.collider.GetComponentInChildren<Health>();
        if (healthOther != null)
        {
            healthOther.TakeDamage(DamageAmount, damageType);
            Debug.Log("did Damage");
        }
    }
}
