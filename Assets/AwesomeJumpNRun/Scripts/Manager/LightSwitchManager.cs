using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchManager : MonoBehaviour {

    [SerializeField]
    public Light mylight;
    public GameObject mydirectionLight; 
    

    private void OnTriggerEnter(Collider other)
    {
        mydirectionLight = GameObject.Find("Directional Light");
        if (other.gameObject.CompareTag("Player"))
        {
            if ((other.gameObject.transform.position.z) < (this.gameObject.transform.position.z))
            {
                mylight.GetComponent<Light>().intensity = 0.0f;
                mydirectionLight.SetActive(false);
                RenderSettings.ambientLight = Color.black;
            }
            else
            {
                mylight.GetComponent<Light>().intensity = 1.0f;
                mydirectionLight.SetActive(true);
            }
        }
    }
}
