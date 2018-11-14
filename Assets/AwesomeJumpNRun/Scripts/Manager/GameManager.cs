using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform player;

    private void Start()
    {
        player.position = spawnPosition.position;
        player.rotation = spawnPosition.rotation;
    }
}