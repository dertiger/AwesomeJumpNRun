using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int maxHp = 100;

    public event Action OnDied = delegate { };
    public event Action<float> OnHpPercentChange = delegate { };

    private int currentHp;

    protected virtual int CurrentHp
    {
        get
        {
            return currentHp;
        }

        set
        {
            currentHp = value;
        }
    }

    protected virtual void Start()
    {
        CurrentHp = maxHp;
    }

    public void TakeOneHit()
    {
        TakeDamage(CurrentHp, DamageType.ONEHIT);
    }

    public void TakeDamage(int damageAmount, DamageType damageType)
    {
        if(damageType == DamageType.ONEHIT)
        {
            damageAmount = CurrentHp;
        }
        CurrentHp -= damageAmount;

        HpPercentChange();

        if (CurrentHp <= 0)
        {
            Die();
        }
    }

    private void HpPercentChange()
    {
        float HpPercent = (float)CurrentHp / (float)maxHp;
        OnHpPercentChange(HpPercent);
    }

    protected virtual void Die()
    {
        OnDied();
    }
}
