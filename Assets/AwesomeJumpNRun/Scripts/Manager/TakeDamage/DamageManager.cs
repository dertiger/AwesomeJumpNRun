using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageManager : MonoBehaviour
{
    protected Health health;

    protected virtual void Start()
    {
        health = GetComponent<Health>();
    }

    protected void DamageManager_ObjectCollided(Collision obj)
    {
        Damage damage = obj.collider.GetComponent<Damage>();
        if (damage != null)
        {
            health.TakeDamage(damage.DamageAmount);
            Debug.Log("took Damage");
        }
    }
}