using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour {

    public GameObject remains;

    // Use this for initialization
    void OnDestroy()
    {
        //Splitter the Destroyed Object
        Debug.Log("OnDestroy1");
        Instantiate(remains, transform.position, transform.rotation);

    }
    void Update()
    {

    }
}
