using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMove : Move
{
    protected override void Start()
    {
        rigBody = GetComponentInParent<Rigidbody>();
        //TODO: why is the InputManager here found via FindGameObjectWithTag and not inserted?
        GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>().Move += OnMove;
    }

    private void OnMove(MoveDirection direction)
    {
        moveDirection = direction;
    }
}