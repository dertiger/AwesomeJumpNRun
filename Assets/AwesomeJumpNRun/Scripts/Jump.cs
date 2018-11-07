using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
    [SerializeField] InputManager inputManager;
    [SerializeField] int jumpHeight;

    private bool jump = false;

    private Rigidbody thisRigidbody;
	// Use this for initialization
	void Start () {
        thisRigidbody = GetComponent<Rigidbody>();
        inputManager.Jump += onJump;
	}

    private void onJump()
    {
        jump = true;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void FixedUpdate()
    {
        CheckJump();
    }

    private void CheckJump()
    {
        if (jump)
        {
            thisRigidbody.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Acceleration);
            jump = false;
        }
    }
}
