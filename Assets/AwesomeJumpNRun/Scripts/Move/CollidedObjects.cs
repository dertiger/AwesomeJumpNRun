using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidedObjects : MonoBehaviour
{
    public event Action<Collision> ObjectCollided = delegate { };

    private List<GameObject> triggeredObjects;

    private void Start()
    {
        triggeredObjects = new List<GameObject>();
    }

    public GameObject GetDimensionChangeObject()
    {
        foreach (var collidedObject in triggeredObjects)
        {
            if (collidedObject.CompareTag("DimensionPoint"))
            {
                return collidedObject;
            }
        }
        return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        triggeredObjects.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        triggeredObjects.Remove(other.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        ObjectCollided(other);
    }
}