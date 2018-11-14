using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform player;

    private void Start()
    {
        var pos = spawnPosition.position;
        pos.y += player.transform.localScale[1] / 2;
        player.position = pos;
        player.rotation = spawnPosition.rotation;
    }
}