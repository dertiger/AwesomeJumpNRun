using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : Move {

	// Use this for initialization
	public override void Start () {
        base.Start();
        moveDirection = MoveDirection.LEFT;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (coliderRightOrLeft(collision))
        {
            InvertMoveDirection();
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
        if (((otherTransform.position.y + otherTransform.localScale.y / 2) <= (transform.position.y - transform.localScale.y / 2)) ||
            (otherTransform.position.y - otherTransform.localScale.y / 2) >= (transform.position.y + transform.localScale.y / 2))
        {
            return false;
        }
        return true;
    }
}
