using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerPosition playerPosition;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private OutOfMap outOfMap;
    [SerializeField] private InputManager inputManager;

    [SerializeField] private List<GameObject> players;
    public event Action PlayerJumped = delegate { };
    public event Action PlayerDescending = delegate { };
    public event Action PlayerDied = delegate { };

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
        rigbody = GetComponent<Rigidbody>();
        Player = 0;
        outOfMap.PlayerFellOutOfMap += OnPlayerFellOutOfMap;
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
        if(myPlayer != null)
        {
            Destroy(myPlayer);
        }
        myPlayer = Instantiate(player, transform);
        PlayerHealth playerHealth = GetComponentInChildren<PlayerHealth>();
        playerHealth.OnDied += OnDied;
        uIManager.setHealthSO(playerHealth.HealthSO);
    }

    private void OnDied()
    {
        //TODO: Next charakter
        //TODO: this Charakter Dies
        rigbody.isKinematic = true;
        PlayerDied();
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