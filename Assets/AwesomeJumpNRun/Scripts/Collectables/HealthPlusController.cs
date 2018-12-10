using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlusController : MonoBehaviour {

    private void onTriggerEntder(Collider other) {
        if (other.gameObject.CompareTag("Player")){
            //Set health to 100%
        }
    }
}
