using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPlattform : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter (Collision other) {
        if (other.gameObject.CompareTag("Plattform")) {
            
        }
	}
}
