using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShoot : MonoBehaviour {
    [SerializeField] private int speed;

    private void Start () {
        Rigidbody rigBody = GetComponent<Rigidbody>();
        rigBody.AddForce(transform.forward * speed);
	}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
