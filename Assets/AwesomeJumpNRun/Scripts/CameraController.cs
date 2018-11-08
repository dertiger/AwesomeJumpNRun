using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] SoPlayerPosition soPlayerPosition;
    [SerializeField] SoCameraOffset soCameraOffset;
    private Transform myTransform;
	// Use this for initialization
	void Start () {
        myTransform = GetComponent<Transform>();
	}

    private void LateUpdate()
    {
        myTransform.position = soPlayerPosition.position + soCameraOffset.position;
    }
}
