using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerPosition playerPosition;

    private void Update()
    {
        playerPosition.ObjectPosition = transform.position;
    }
}