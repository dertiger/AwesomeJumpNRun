using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfMap : MonoBehaviour
{
    public event Action PlayerFellOutOfMap = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerFellOutOfMap();
        }
    }
}