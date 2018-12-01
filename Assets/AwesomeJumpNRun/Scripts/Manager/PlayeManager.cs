using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeManager : MonoBehaviour
{
    public event Action PlayerJumped = delegate { };
    public event Action PlayerDescending = delegate { };

    private Rigidbody rigbody;
    private Health playerHealth;

    void Start()
    {
        rigbody = GetComponent<Rigidbody>();
        InitializePlayerParameters();
    }

    private void InitializePlayerParameters()
    {
        playerHealth = GetComponentInChildren<Health>();
        playerHealth.OnDied += OnDied;
    }

    private void OnDied()
    {
        //TODO: Next charakter
        //TODO: this Charakter Dies
        throw new NotImplementedException();
    }

    private void FixedUpdate()
    {
        if(rigbody.velocity.y <= 0)
        {
            PlayerDescending();
        }
        else
        {
            PlayerJumped();
        }
    }

    private void TakeDamage(int damageAmount)
    {
        playerHealth.TakeDamage(damageAmount);
    }
}
