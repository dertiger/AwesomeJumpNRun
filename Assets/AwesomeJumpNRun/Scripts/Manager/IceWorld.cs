using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWorld : MonoBehaviour
{

    private GameObject lightobject;
    private Light light;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lightobject = GameObject.Find("Directional Light");
            light = lightobject.GetComponent<Light>();
            Color lightblue = new Color32(0, 247, 255, 255);
            light.color = lightblue;
            
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
