using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPlattform : MonoBehaviour {
    private Joint theJoint;
    private bool onPlattform = false;

    // Use this for initialization
    void OnCollisionEnter (Collision other) {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.AddComponent<FixedJoint>();
            gameObject.GetComponent<FixedJoint>().connectedBody = other.rigidbody;
            gameObject.GetComponent<FixedJoint>().massScale = 0.01f;
            onPlattform = true;
        }
       
    }

    void Update() {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            Destroy(gameObject.GetComponent<FixedJoint>());
        }

        if (Input.GetKey("space"))
        {
            onPlattform = false;
            Destroy(gameObject.GetComponent<FixedJoint>());
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (onPlattform) {
                GameObject player = GameObject.Find("Player");
                gameObject.AddComponent<FixedJoint>();
                gameObject.GetComponent<FixedJoint>().connectedBody = player.GetComponent<Rigidbody>();
                gameObject.GetComponent<FixedJoint>().massScale = 0.01f;
            }
        }
    }
}
