using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : Move
{
    [SerializeField] private int ingnoreLayer;

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
            if (!LayerMask.LayerToName(collision.collider.gameObject.layer).Equals("PlayerShoot"))
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
}