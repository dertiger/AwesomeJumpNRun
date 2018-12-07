using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public event Action ShouldRestartGame = delegate { };

    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform player;

    [SerializeField] private int gameTime = 300;
    [SerializeField] private GameTime gameTimeHandler;

    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private InputManager inputManager;

    [SerializeField] private BossRoomEnter bossRoomEnter;

    private void Start()
    {
        var pos = spawnPosition.position;
        pos.y += player.transform.localScale[1] / 2;
        player.position = pos;
        player.rotation = spawnPosition.rotation;

        gameTimeHandler.CurrentGameTime = gameTime;
        gameTimeHandler.GameTimeExpired += OnGameTimeExpired;
        StartCoroutine(gameTimeHandler.StartGameTimer());

        playerManager.PlayerDied += OnPlayerDied;
        inputManager.RestartGame += OnRestartGame;

        bossRoomEnter.EnterBossroom += OnEnterBossroom;
    }

    private void OnEnterBossroom()
    {
        PlayerShouldRestartGame();
    }

    private void OnRestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnPlayerDied()
    {
        PlayerShouldRestartGame();
    }

    private void OnGameTimeExpired()
    {
        PlayerShouldRestartGame();
    }

    private void PlayerShouldRestartGame()
    {
        ShouldRestartGame();
        inputManager.ForcePlayerToRestart();
    }
}