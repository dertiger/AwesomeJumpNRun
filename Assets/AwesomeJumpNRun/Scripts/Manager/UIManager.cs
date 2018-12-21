using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameTime;
    [SerializeField] private GameTime gameTimeHandler;
    [SerializeField] private TextMeshProUGUI health;

    [SerializeField] private Points pointsSO;
    [SerializeField] private TextMeshProUGUI points;

    [SerializeField] private Keys keysSO;
    [SerializeField] private TextMeshProUGUI keys;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI shouldRestart;

    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private TextMeshProUGUI activePlayer;
    [SerializeField] private TextMeshProUGUI inactivePlayerLeft;
    [SerializeField] private TextMeshProUGUI inactivePlayerRight;

    [SerializeField] private List<HealthSO> healthSOs;

    private HealthSO healthSO;

    private void Start()
    {
        gameManager.ShouldRestartGame += OnShouldRestartGame;
        playerManager.PlayerChanged += OnPlayerChanged;
        playerManager.PlayerDied += OnPlayerDied;
        foreach (var healthSo in healthSOs)
        {
            if (healthSo.name.Equals("Jumper"))
            {
                this.healthSO = healthSo;
                break;
            }
        }
    }

    private void OnDestroy()
    {
        gameManager.ShouldRestartGame -= OnShouldRestartGame;
    }

    private void OnShouldRestartGame()
    {
        shouldRestart.enabled = true;
    }

    private void FixedUpdate()
    {
        gameTime.text = (gameTimeHandler.CurrentGameTime / 60) + ":" +
                        (gameTimeHandler.CurrentGameTime % 60).ToString("00");
        points.text = "Points: " + pointsSO.CurrentPoints;
        keys.text = keysSO.CurrentKeys + "/" + keysSO.MaxKeys + " Keys";
        if (healthSO != null)
        {
            health.text = (healthSO.AcctualHealth >= 0 ? healthSO.AcctualHealth : 0) + "/" + healthSO.MaxHealth + "LP";
        }
    }

    private void OnPlayerChanged(string playerName)
    {
        if (!activePlayer.text.Equals(playerName))
        {
            var activePlayerBefore = activePlayer.text;
            var lastPlayerfontStyle = activePlayer.fontStyle;
            FontStyles inactivePlayerfontStyle;
            if (inactivePlayerLeft.text.Equals(playerName))
            {
                inactivePlayerfontStyle = inactivePlayerLeft.fontStyle;
                inactivePlayerLeft.text = activePlayerBefore;
                inactivePlayerLeft.fontStyle = lastPlayerfontStyle;
            }
            else
            {
                inactivePlayerfontStyle = inactivePlayerRight.fontStyle;
                inactivePlayerRight.text = activePlayerBefore;
                inactivePlayerRight.fontStyle = lastPlayerfontStyle;
            }
            activePlayer.text = playerName;
            activePlayer.fontStyle = inactivePlayerfontStyle;

            foreach (var healthSo in healthSOs)
            {
                if (healthSo.name.Equals(playerName))
                {
                    this.healthSO = healthSo;
                    break;
                }
            }
        }
    }

    private void OnPlayerDied(string playerName)
    {
        if (activePlayer.text.Equals(playerName))
        {
            activePlayer.fontStyle = FontStyles.Strikethrough;
        }
        else if (inactivePlayerLeft.text.Equals(playerName))
        {
            inactivePlayerLeft.fontStyle = FontStyles.Strikethrough;
        }
        else
        {
            inactivePlayerRight.fontStyle = FontStyles.Strikethrough;
        }
    }
}