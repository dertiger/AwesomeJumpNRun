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
}
