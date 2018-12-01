using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int layer = GetComponent<GameObject>().layer;
        LayerMask.LayerToName(layer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
