using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchManager : MonoBehaviour {

    public Light lt;

    private void OnTriggerEnter(Collider other)
    {
        
        lt = GetComponent<Light>();
        lt.color -= (Color.red / 2.0f) * Time.deltaTime;

        if (other.gameObject.CompareTag("Player"))
        {
            if ((other.gameObject.transform.position.z) < (this.gameObject.transform.position.z))
            {
                Destroy(other.gameObject);
            }
            else
            {
                //light up
            }
        }
    }
}
