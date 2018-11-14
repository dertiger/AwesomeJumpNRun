using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMove : Move
{
    protected override void Start()
    {
        base.Start();
        rigBody = GetComponentInParent<Rigidbody>();
        GetComponentInParent<CollidedObjects>().ObjectCollided += CollidedWithObject;
        //TODO: why is the InputManager here found via FindGameObjectWithTag and not inserted?
        GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>().Move += OnMove;
    }

    private void OnMove(MoveDirection direction)
    {
        moveDirection = direction;
    }
}