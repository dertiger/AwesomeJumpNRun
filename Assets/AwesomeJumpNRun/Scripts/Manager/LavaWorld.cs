using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaWorld : MonoBehaviour
{

    private GameObject lightobject;
    private Light myLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lightobject = GameObject.Find("Directional Light");
            myLight = lightobject.GetComponent<Light>();
            myLight.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lightobject = GameObject.Find("Directional Light");
            myLight = lightobject.GetComponent<Light>();
            myLight.color = Color.white;
        }
    }
}
