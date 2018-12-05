using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    [SerializeField] private Transform shootPosition;

    [SerializeField] private PlayerPosition enemyPosition;
    
    private void LateUpdate()
    {
        shootPosition.LookAt(enemyPosition.playerPosition);
    }
}