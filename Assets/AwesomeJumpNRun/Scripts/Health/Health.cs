﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int maxHp = 100;
    [SerializeField] private AudioSource damageSound;
    [SerializeField] private List<DamageTypes> immunitys;

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
        TakeDamage(CurrentHp, DamageTypes.ONEHIT);
    }

    public void TakeDamage(int damageAmount, DamageTypes damageType)
    {
        if (!immunitys.Contains(damageType))
        {
            if (damageType == DamageTypes.ONEHIT)
            {
                damageAmount = CurrentHp;
            }
            if (damageAmount >= 0)
            {
                playSound();
            }
            CurrentHp -= damageAmount;

            HpPercentChange();

            if (CurrentHp <= 0)
            {
                CurrentHp = 0;
                Die();
            }
            if (CurrentHp > maxHp)
            {
                CurrentHp = maxHp;
            }
        }
        else
        {
            Debug.Log("Was imune");
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

    private void playSound()
    {
        if(damageSound != null)
        {
            if (!damageSound.isPlaying)
            {
                damageSound.Play();
            }
        }
    }
}
