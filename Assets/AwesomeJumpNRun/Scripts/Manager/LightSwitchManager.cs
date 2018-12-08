using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchManager : MonoBehaviour
{
    [SerializeField] private Light mylight;
    [SerializeField] private Camera cam;
    public GameObject[] players;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cam.backgroundColor = Color.black;
            RenderSettings.fogColor = Color.black;
            RenderSettings.ambientIntensity = 0;
            RenderSettings.reflectionIntensity = 0;
            //Turn off lights
            mylight.GetComponent<Light>().intensity = 0.0f;
            //Make player a light
            players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                player.GetComponent<Light>().intensity = 10.0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cam.backgroundColor = new Color(0.3490566f, 0.3490566f, 0.3490566f);
            RenderSettings.fogColor = new Color(0.3490566f, 0.3490566f, 0.3490566f);
            RenderSettings.ambientIntensity = 1;
            RenderSettings.reflectionIntensity = 1;
            //Turn lights on
            mylight.GetComponent<Light>().intensity = 1.0f;
            //Remove light from player
            players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                player.GetComponent<Light>().intensity = 0.0f;
            }
        }
    }
}