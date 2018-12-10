using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour {

    // Use this for initialization
    void OnDestroy()
    {
        //Splitter the Destroyed Object
        Debug.Log("OnDestroy1");
    }
}
