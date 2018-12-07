using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchManager : MonoBehaviour {

    [SerializeField]
    public Light mylight;
  

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            mylight.GetComponent<Light>().intensity = 0.0f;   
        }
    }

    private void OnTriggerExit(Collider other) {

        if (other.gameObject.CompareTag("Player"))
        {
            mylight.GetComponent<Light>().intensity = 3.0f;
        }
    }
}
