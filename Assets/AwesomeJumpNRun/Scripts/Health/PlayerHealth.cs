using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health {
    [SerializeField] private HealthSO healthSO;

    protected override void Start()
    {
        base.Start();
        healthSO.MaxHealth = maxHp;
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
            healthSO.AcctualHealth = base.CurrentHp;
        }
    }
}
