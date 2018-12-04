using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerHealth", menuName ="PlayerHealth", order =1)]
public class HealthSO : ScriptableObject {
    [SerializeField] private int acctualHealth;
    [SerializeField] private int maxHealth;

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }

        set
        {
            maxHealth = value;
        }
    }

    public int AcctualHealth
    {
        get
        {
            return acctualHealth;
        }

        set
        {
            acctualHealth = value;
        }
    }
}
