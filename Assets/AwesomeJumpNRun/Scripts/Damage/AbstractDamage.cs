using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDamage : MonoBehaviour {
    [SerializeField] private int damageAmount;
    [SerializeField] private DamageTypes damageType;

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

    public DamageTypes DamageType
    {
        get
        {
            return damageType;
        }

        set
        {
            damageType = value;
        }
    }
}
