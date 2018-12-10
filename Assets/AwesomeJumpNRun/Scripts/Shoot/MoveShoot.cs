using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShoot : MonoBehaviour {
    [SerializeField] private int speed;

    private void Start () {
        Rigidbody rigBody = GetComponent<Rigidbody>();
        rigBody.AddForce(transform.forward * speed);
        StartCoroutine(TimebasedDestroy(10));
	}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private IEnumerator TimebasedDestroy(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
