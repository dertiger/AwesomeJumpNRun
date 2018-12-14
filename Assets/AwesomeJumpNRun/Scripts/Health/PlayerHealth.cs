using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health {
    [SerializeField] private HealthSO healthSO;
    public HealthSO HealthSO
    {
        get
        {
            return healthSO;
        }

        private set
        {
            healthSO = value;
        }
    }

    protected override int CurrentHp
    {
        get
        {
            return base.CurrentHp;
        }

        set
        {
            base.CurrentHp = value;
            HealthSO.AcctualHealth = base.CurrentHp;
        }
    }

    protected override void Start()
    {
        int currentHealth = healthSO.AcctualHealth;
        base.Start();
        CurrentHp = currentHealth;
        HealthSO.MaxHealth = maxHp;
    }
}
