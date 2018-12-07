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
            //Turn off lights
            mylight.GetComponent<Light>().intensity = 0.0f;
            //Make player a light
            players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                player.GetComponent<Light>().intensity = 10.0f;
            }
            //Make it black 
            GameObject.Find("CaveWall1").transform.localScale = new Vector3(0.2f, 27.0f, 67.0f);
            GameObject.Find("CaveWall2").transform.localScale = new Vector3(48.0f, 36.0f, 0.5f);
            GameObject.Find("CaveWall3").transform.localScale = new Vector3(0.0001f, 27.0f, 20f);

            //Make Collectables Glow

        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            //Turn lights on
            mylight.GetComponent<Light>().intensity = 3.0f;
            //Remove light from player
            players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                player.GetComponent<Light>().intensity = 0.0f;
            }
            //Make it bright
            GameObject.Find("CaveWall1").transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
            GameObject.Find("CaveWall2").transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
            GameObject.Find("CaveWall3").transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);

            //Make Collectables unglow
        }
    }
}
