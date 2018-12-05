using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : Shoot
{
    private bool playerInRange;

    protected override void Start()
    {
        base.Start();
        GetComponent<CollidedObjects>().PlayerCollidedWithTrigger += OnPlayerCollidedWithTrigger;
        GetComponent<CollidedObjects>().PlayerLeftTrigger += OnPlayerLeftTrigger;
    }

    private void OnPlayerCollidedWithTrigger(Collider obj)
    {
        playerInRange = true;
    }

    private void OnPlayerLeftTrigger()
    {
        playerInRange = false;
    }


    private void Update()
    {
        if (playerInRange)
        {
            OnShoot();
        }
    }
}