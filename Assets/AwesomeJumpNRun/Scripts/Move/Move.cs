using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Move : MonoBehaviour
{
    [SerializeField] private int movementSpeed;

    [SerializeField] private List<int> movementModifiersInPercent = new List<int>();

    [SerializeField] protected float stepSize = 0.2f;

    protected Rigidbody rigBody;
    protected MoveDirection moveDirection = MoveDirection.STOP;

    protected virtual void Start()
    {
        rigBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (moveDirection == MoveDirection.RIGHT)
        {
            MoveInDirection(transform.forward);
        }
        else if (moveDirection == MoveDirection.LEFT)
        {
            MoveInDirection(-transform.forward);
        }
        else if (moveDirection == MoveDirection.STOP)
        {
            MoveInDirection(Vector3.zero);
        }
    }

    private void MoveInDirection(Vector3 direction)
    {
        direction = direction * CalcSpeedModifier();
        rigBody.velocity = new Vector3(direction.x, rigBody.velocity.y, direction.z);
    }

    private float CalcSpeedModifier()
    {
        float speedmodifier = movementSpeed;
        foreach (var percent in movementModifiersInPercent)
        {
            speedmodifier *= (float) percent / 100;
        }

        return speedmodifier;
    }

    protected void CollidedWithObject(GameObject other)
    {
        var stepDifference = GetStepDifference(other);

        if (stepDifference >= 0 && stepDifference <= stepSize)
        {
            var gameObjectTransform = rigBody.transform;
            var pos = gameObjectTransform.position;
            pos.y += stepDifference;
            if (moveDirection == MoveDirection.LEFT)
            {
                pos = pos - gameObjectTransform.forward * 0.05f;
            }
            else if (moveDirection == MoveDirection.RIGHT)
            {
                pos = pos + gameObjectTransform.forward * 0.05f;
            }

            gameObjectTransform.position = pos;
        }
    }

    protected float GetStepDifference(GameObject other)
    {
        var ownBounds = GetComponent<Collider>().bounds;
        var otherBounds = other.GetComponent<Collider>().bounds;

        var ownBot = ownBounds.min.y;
        var otherTop = otherBounds.max.y;

        return otherTop - ownBot;
    }
}