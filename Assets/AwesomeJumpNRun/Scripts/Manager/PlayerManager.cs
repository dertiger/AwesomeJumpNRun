using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerPosition playerPosition;
    [SerializeField] private OutOfMap outOfMap;
    [SerializeField] private InputManager inputManager;

    [SerializeField] private List<GameObject> players;
    public event Action PlayerJumped = delegate { };
    public event Action PlayerDescending = delegate { };
    public event Action PlayerDied = delegate { };
    public event Action<string> PlayerChanged = delegate { };

    private Rigidbody rigbody;
    private int player;
    private GameObject myPlayer = null;

    public int Player
    {
        get
        {
            return player;
        }

        set
        {
            if (value < 0)
            {
                player = players.Count - 1;
            }
            else if (value > players.Count - 1)
            {
                player = 0;
            }
            else
            {
                player = value;
            }
            InitializePlayerParameters(players[Player]);
        }
    }

    private void Start()
    {
        inputManager.NextChar += OnNextChar;
        inputManager.PerviousChar += OnPerviousChar;
        outOfMap.PlayerFellOutOfMap += OnPlayerFellOutOfMap;
        setPlayersHealthToMax();
        rigbody = GetComponent<Rigidbody>();
        Player = 0;
    }

    private void OnPerviousChar()
    {
        Player--;
    }

    private void OnNextChar()
    {
        Player++;
    }

    private void OnPlayerFellOutOfMap()
    {
        rigbody.isKinematic = true;
        PlayerDied();
    }

    private void InitializePlayerParameters(GameObject player)
    {
        if (PlayerAlive(player))
        {
            if (myPlayer != null)
            {
                Destroy(myPlayer);
            }
            myPlayer = Instantiate(player, transform);
            PlayerHealth playerHealth = myPlayer.GetComponentInChildren<PlayerHealth>();
            playerHealth.OnDied += OnDied;
            PlayerChanged(myPlayer.name.Split('(')[0]);
        }
        else
        {
            OnNextChar();
        }
    }

    private void setPlayersHealthToMax()
    {
        foreach (GameObject myPlayer in players)
        {
            PlayerHealth playerHealth = myPlayer.GetComponentInChildren<PlayerHealth>();
            playerHealth.HealthSO.AcctualHealth = playerHealth.HealthSO.MaxHealth;
        }
    }

    private void OnDied()
    {
        if (AllPlayerDead())
        {
            rigbody.isKinematic = true;
            PlayerDied();
        }
        else
        {
            OnNextChar();
        }
    }

    private bool PlayerAlive(GameObject player)
    {
        PlayerHealth playerhealth = player.GetComponentInChildren<PlayerHealth>();
        if (playerhealth != null)
        {
            if(playerhealth.HealthSO.AcctualHealth <= 0)
            {
                return false;
            }
        }
        return true;
    }

    private bool AllPlayerDead()
    {
        foreach(GameObject player in players)
        {
            if (PlayerAlive(player))
            {
                return false;
            }
        }
        return true;
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
}