using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerPosition playerPosition;
    [SerializeField] private CameraOffset cameraOffset;
    private Transform myTransform;

    private void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        myTransform.position = playerPosition.ObjectPosition + cameraOffset.ObjectPosition;
    }
}