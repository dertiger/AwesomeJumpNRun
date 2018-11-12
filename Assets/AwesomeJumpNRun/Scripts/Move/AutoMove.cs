using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : Move {
    
    protected override void Start () {
        base.Start();
        MoveDirection = MoveDirection.LEFT;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (ColiderRightOrLeft(collision))
        {
            InvertMoveDirection();
        }
    }

    private void InvertMoveDirection()
    {
        if (MoveDirection == MoveDirection.LEFT)
        {
            MoveDirection = MoveDirection.RIGHT;
        }
        else
        {
            MoveDirection = MoveDirection.LEFT;
        }
    }

    private bool ColiderRightOrLeft(Collision collision)
    {
        var otherTransform = collision.collider.transform;
        if (otherTransform.position.y + otherTransform.localScale.y / 2 <= transform.position.y - transform.localScale.y / 2 ||
            otherTransform.position.y - otherTransform.localScale.y / 2 >= transform.position.y + transform.localScale.y / 2)
        {
            return false;
        }
        return true;
    }
}
