using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Move : MonoBehaviour
{
    [SerializeField] private int movementSpeed;

    [SerializeField] private List<int> movementModifiersInPercent = new List<int>();

    private Rigidbody rigBody;
    protected MoveDirection MoveDirection = MoveDirection.STOP;


    protected virtual void Start()
    {
        rigBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (MoveDirection == MoveDirection.RIGHT)
        {
            MoveInDirection(transform.forward);
        }
        else if (MoveDirection == MoveDirection.LEFT)
        {
            MoveInDirection(-transform.forward);
        }
        else if (MoveDirection == MoveDirection.STOP)
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
}