using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveHandler : MonoBehaviour, IMovementHandler
{
    public event Action<MoveDirection> Move = delegate { };

    private MoveDirection moveDirection = MoveDirection.LEFT;
    // Use this for initialization
    void Start()
    {
        Move(moveDirection);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (coliderRightOrLeft(collision))
        {
            InvertMoveDirection();
            Move(moveDirection);
        }
    }

    private void InvertMoveDirection()
    {
        if (moveDirection == MoveDirection.LEFT)
        {
            moveDirection = MoveDirection.RIGHT;
        }
        else
        {
            moveDirection = MoveDirection.LEFT;
        }
    }

    private bool coliderRightOrLeft(Collision collision)
    {
        Transform otherTransform = collision.collider.transform;
        if(((otherTransform.position.y + otherTransform.localScale.y/2) <= (transform.position.y - transform.localScale.y / 2)) ||
            (otherTransform.position.y - otherTransform.localScale.y / 2) >= (transform.position.y + transform.localScale.y / 2))
        {
            return false;
        }
        return true;
    }
}
