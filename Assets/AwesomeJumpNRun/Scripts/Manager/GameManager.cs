using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform player;

    [SerializeField] private int gameTime = 300;
    [SerializeField] private GameTime gameTimeHandler;

    private void Start()
    {
        var pos = spawnPosition.position;
        pos.y += player.transform.localScale[1] / 2;
        player.position = pos;
        player.rotation = spawnPosition.rotation;

        gameTimeHandler.CurrentGameTime = gameTime;
        gameTimeHandler.GameTimeExpired += OnGameTimeExpired;
        StartCoroutine(gameTimeHandler.StartGameTimer());
    }

    private void OnGameTimeExpired()
    {
        Debug.Log("GameTime expired");
    }
}