using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerPosition playerPosition;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private OutOfMap outOfMap;

    [SerializeField] private List<HealthSO> healthSOs;
    public event Action PlayerJumped = delegate { };
    public event Action PlayerDescending = delegate { };
    public event Action PlayerDied = delegate { };

    private Rigidbody rigbody;
    private Health playerHealth;

    private void Start()
    {
        rigbody = GetComponent<Rigidbody>();
        InitializePlayerParameters();
        uIManager.setHealthSO(healthSOs[1]);

        outOfMap.PlayerFellOutOfMap += OnPlayerFellOutOfMap;
    }

    private void OnPlayerFellOutOfMap()
    {
        rigbody.isKinematic = true;
        PlayerDied();
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
        rigbody.isKinematic = true;
        PlayerDied();
    }

    private void Update()
    {
        playerPosition.playerPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (rigbody.velocity.y <= 0)
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