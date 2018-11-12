using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputJumpHandler : MonoBehaviour, IJumpHandler
{
    [SerializeField] private InputManager inputManager;

    public event Action Jump = delegate { };

    private void Start()
    {
        inputManager.Jump += InputManager_Jump;
    }

    private void InputManager_Jump()
    {
        Jump();
    }
}