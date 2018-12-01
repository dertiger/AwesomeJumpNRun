using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHp = 100;
    public event Action OnDied = delegate { };
    public event Action<float> OnHpPercentChange = delegate { };

    private int currentHp;

    private void Start()
    {
        currentHp = maxHp;
    }

    public void TakeOneHit()
    {
        TakeDamage(currentHp);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHp -= damageAmount;

        HpPercentChange();

        if (currentHp <= 0)
        {
            Die();
        }
    }

    private void HpPercentChange()
    {
        float HpPercent = (float)currentHp / (float)maxHp;
        OnHpPercentChange(HpPercent);
    }

    private void Die()
    {
        OnDied();
    }
}
