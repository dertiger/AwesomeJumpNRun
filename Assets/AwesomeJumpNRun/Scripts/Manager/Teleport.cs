using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public GameObject[] players;

    // Use this for initialization
    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Player"))
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                player.transform.position = new Vector3(0.0f, 1.0f, -30.0f);
            }
        }
        
    }
}
