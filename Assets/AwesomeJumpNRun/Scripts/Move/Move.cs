using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Move : MonoBehaviour{
    [SerializeField] private int movementSpeed;

    public List<int> movementModifiersInPercent = new List<int>();

    private Rigidbody thisRigidbody;
    protected MoveDirection moveDirection = MoveDirection.STOP;

    // Use this for initialization
    public virtual void Start ()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (moveDirection == MoveDirection.RIGHT)
        {
            move(transform.forward);
        }
        else if (moveDirection == MoveDirection.LEFT)
        {
            move(-transform.forward);
        }
        else if (moveDirection == MoveDirection.STOP)
        {
            move(Vector3.zero);
        }
    }

    private void move(Vector3 direction)
    {
        direction = direction * calcSpeedModifier();
        thisRigidbody.velocity = new Vector3(direction.x, thisRigidbody.velocity.y, direction.z);
    }

    private float calcSpeedModifier()
    {
        float speedmodifier = movementSpeed;
        foreach (int percent in movementModifiersInPercent)
        {
            speedmodifier *= (float)percent / 100;
        }
        return speedmodifier;
    }
}
