using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMoveHandler : MonoBehaviour, IMovementHandler
{
    [SerializeField] InputManager inputManager;
    public event Action<MoveDirection> Move = delegate { };
    
    void Start()
    {
        inputManager.Move += InputManager_Move;
        Debug.Log("InputMoveHandler Registered");
    }

    private void InputManager_Move(MoveDirection obj)
    {
        Debug.Log("InputMoveHandler: Send Input to all listeners");
        Move(obj);
    }
}
