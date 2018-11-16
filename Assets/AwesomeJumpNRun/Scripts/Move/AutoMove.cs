using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : Move
{
    protected override void Start()
    {
        base.Start();
        GetComponent<CollidedObjects>().ObjectCollided += CollidedWithObject;
        GetComponent<CollidedObjects>().ObjectCollided += CollidedRightOrleft;
        moveDirection = MoveDirection.LEFT;
    }

    private void CollidedRightOrleft(Collision collision)
    {
        var stepDifference = GetStepDifference(collision);
        if (stepDifference > stepSize)
        {
            if (moveDirection == MoveDirection.LEFT)
            {
                moveDirection = MoveDirection.RIGHT;
            }
            else if (moveDirection == MoveDirection.RIGHT)
            {
                moveDirection = MoveDirection.LEFT;
            }
        }
    }
}