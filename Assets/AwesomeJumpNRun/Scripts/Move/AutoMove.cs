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

    private void CollidedRightOrleft(GameObject other)
    {
        var stepDifference = GetStepDifference(other);
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