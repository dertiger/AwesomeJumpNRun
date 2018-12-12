using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaWorld : MonoBehaviour
{

    private GameObject lightobject;
    private Light light;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lightobject = GameObject.Find("Directional Light");
            light = lightobject.GetComponent<Light>();
            light.color = Color.red;
            //light.intensity = 4.0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lightobject = GameObject.Find("Directional Light");
            light = lightobject.GetComponent<Light>();
            light.color = Color.white;
        }
    }
}
