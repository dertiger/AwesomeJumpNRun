using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float minCameraDistance = 7;
    [SerializeField] private float maxCameraDistance = 20;
    [SerializeField] private float cameraChangeRate = 5;
    [SerializeField] private float cameraHeight = 2;

    private bool jumping;
    private bool delayedDescending;
    private Vector3 maxCameraDistanceVector;
    private Vector3 minCameraDistanceVector;

    private float startTime;
    private Vector3 maxLearpDist;
    private float jurneyLength;
    
    private void Start()
    {
        maxCameraDistanceVector = new Vector3(maxCameraDistance, cameraHeight, 0);
        minCameraDistanceVector = new Vector3(minCameraDistance, cameraHeight, 0);
        var playerManager = GetComponentInParent<PlayeManager>();
        playerManager.PlayerJumped += OnJump;
        playerManager.PlayerDescending += OnLand;
        startTime = Time.time;

        jurneyLength = Vector3.Distance(maxCameraDistanceVector, minCameraDistanceVector);
    }

    private void FixedUpdate()
    {
        float distCovered = (Time.time - startTime) * 10;

        float fractJurney = distCovered / jurneyLength;

        maxCameraDistanceVector = new Vector3(maxCameraDistance, cameraHeight, 0);
        minCameraDistanceVector = new Vector3(minCameraDistance, cameraHeight, 0);
        if (jumping)
        {
            gameObject.transform.localPosition = Vector3.Lerp(gameObject.transform.localPosition, maxCameraDistanceVector, cameraChangeRate * Time.deltaTime);
        }
        else if (!delayedDescending)
        {
           gameObject.transform.localPosition = Vector3.Lerp(maxLearpDist, minCameraDistanceVector, fractJurney);
        }
    }

    private void OnJump()
    {
        if (!jumping)
        {
            startTime = Time.time;
            jurneyLength = Vector3.Distance(minCameraDistanceVector, maxCameraDistanceVector);
        }
        jumping = true;
    }

    private void OnLand()
    {
        if (jumping) {
            StartCoroutine(DelayedLanding());
            maxLearpDist = gameObject.transform.localPosition;
        }
        jumping = false;
    }

    private IEnumerator DelayedLanding()
    {
        delayedDescending = true;
        yield return new WaitForSeconds(0.1f);
        startTime = Time.time;
        jurneyLength = Vector3.Distance(maxLearpDist, minCameraDistanceVector);
        delayedDescending = false;
    }
}
