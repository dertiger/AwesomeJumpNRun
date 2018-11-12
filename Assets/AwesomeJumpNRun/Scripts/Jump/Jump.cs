using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private int jumpHeight;

    private bool isJumping;
    private Rigidbody rigBody;

    private void Start()
    {
        rigBody = GetComponent<Rigidbody>();
        GetComponentInParent<IJumpHandler>().Jump += OnJump;
    }

    private void OnJump()
    {
        if (!isJumping)
        {
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