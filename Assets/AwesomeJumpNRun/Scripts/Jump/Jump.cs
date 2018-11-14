using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Jump : MonoBehaviour
{
    [SerializeField] private int jumpHeight;
    public event Action ObjectJumped = delegate { };

    private bool isJumping;
    private Rigidbody rigBody;

    protected virtual void Start()
    {
        rigBody = GetComponentInParent<Rigidbody>();
    }

    protected void OnJump()
    {
        if (!isJumping)
        {
            ObjectJumped();
            isJumping = true;
            rigBody.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Acceleration);
            StartCoroutine(DelayJump());
        }
    }

    private IEnumerator DelayJump()
    {
        yield return new WaitForSeconds(1f);
        isJumping = false;
    }
}