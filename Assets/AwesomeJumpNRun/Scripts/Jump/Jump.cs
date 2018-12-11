using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Jump : MonoBehaviour
{
    [SerializeField] private int jumpHeight;
    public event Action ObjectJumped = delegate { };

    private int canJump;
    private bool onGround = true;
    private Rigidbody rigBody;

    protected virtual void Start()
    {
        rigBody = GetComponentInParent<Rigidbody>();
        GetComponentInParent<CollidedObjects>().ObjectCollided += OnObjectCollided;
        canJump = 2;
    }

    private void OnObjectCollided(Collision obj)
    {
        if (GetStepDifference(obj) < 0.2f)
        {
            canJump = 2;
            onGround = true;
        }
    }

    protected void OnJump()
    {
        if (canJump > 0)
        {
            ObjectJumped();
            onGround = false;
            canJump--;
            rigBody.velocity = new Vector3(rigBody.velocity.x, jumpHeight, rigBody.velocity.z);
            StartCoroutine(WaitForJump());
        }
    }

    private IEnumerator WaitForJump()
    {
        yield return new WaitForSeconds(1f);
        if (!onGround)
        {
            canJump = 0;
        }
    }

    private float GetStepDifference(Collision collision)
    {
        var ownBounds = GetComponent<Collider>().bounds;
        var otherBounds = collision.collider.bounds;

        var ownBot = ownBounds.min.y;
        var otherTop = otherBounds.max.y;

        return otherTop - ownBot;
    }

    protected virtual void OnDestroy()
    {
        var collidedObjects = GetComponentInParent<CollidedObjects>();
        if (collidedObjects != null)
        {
            collidedObjects.ObjectCollided -= OnObjectCollided;
        }
    }
}