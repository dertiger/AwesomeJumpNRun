using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidedObjects : MonoBehaviour
{
    private List<GameObject> collidedObjects;

    private void Start()
    {
        collidedObjects = new List<GameObject>();
    }

    public GameObject GetDimensionChangeObject()
    {
        foreach (var collidedObject in collidedObjects)
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
        collidedObjects.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        collidedObjects.Remove(other.gameObject);
    }
}