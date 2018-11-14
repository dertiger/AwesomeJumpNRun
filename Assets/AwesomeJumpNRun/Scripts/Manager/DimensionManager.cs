using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    private Quaternion rotation;
    private Vector3 position;
    private bool switchDimension;
    private float timer = 0;

    private void Start()
    {
        inputManager.ChangeDimension += OnChangeDimension;
        rotation = gameObject.transform.rotation;
    }

    private void OnChangeDimension()
    {
        var dimensionChangeObject = GetComponent<CollidedObjects>().GetDimensionChangeObject();
        if (dimensionChangeObject != null && !switchDimension)
        {
            switchDimension = true;
            if (Math.Abs(rotation.y - Quaternion.Euler(0, -90, 0).y) < 0.05)
            {
                rotation *= Quaternion.Euler(0, 90, 0);
            }
            else
            {
                rotation *= Quaternion.Euler(0, -90, 0);
            }

            position = gameObject.transform.position;
            position.x = dimensionChangeObject.transform.position.x;
            position.z = dimensionChangeObject.transform.position.z;
        }
    }

    private void LateUpdate()
    {
        var objectTransform = gameObject.transform;
        if (timer >= 1)
        {
            timer = 0;
            switchDimension = false;
        }

        if (switchDimension)
        {
            timer += Time.deltaTime;
            objectTransform.rotation = Quaternion.Lerp(objectTransform.rotation, rotation, 5 * Time.deltaTime);
            objectTransform.position = Vector3.Lerp(objectTransform.position, position, 5 * Time.deltaTime);
        }
    }
}