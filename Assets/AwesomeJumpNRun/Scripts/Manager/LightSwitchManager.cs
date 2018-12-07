using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchManager : MonoBehaviour {

    [SerializeField]
    public Light mylight;
    public GameObject[] players;
    

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            mylight.GetComponent<Light>().intensity = 0.0f;
            foreach (GameObject player in players)
            {
                player.GetComponent<Light>().intensity = 10.0f;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            mylight.GetComponent<Light>().intensity = 3.0f;
            foreach (GameObject player in players)
            {
                player.GetComponent<Light>().intensity = 0.0f;
            }
        }
    }
}
