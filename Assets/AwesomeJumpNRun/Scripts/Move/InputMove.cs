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
        GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>().Move += OnMove;
    }

    private void OnMove(MoveDirection direction)
    {
        moveDirection = direction;
    }

    private void OnDestroy()
    {
        var collidedObjects = GetComponentInParent<CollidedObjects>();
        if (collidedObjects != null)
        {
            collidedObjects.ObjectCollided -= CollidedWithObject;
        }

        var inputManager = GameObject.FindGameObjectWithTag("InputManager");
        if (inputManager != null)
        {
            inputManager.GetComponent<InputManager>().Move -= OnMove;
        }
    }
}