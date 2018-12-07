using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidedObjects : MonoBehaviour
{
    public event Action<Collision> ObjectCollided = delegate { };

    public event Action<Collider> PlayerCollidedWithTrigger = delegate { };

    public event Action PlayerLeftTrigger = delegate { };

    private List<GameObject> triggeredObjects;

    private void Start()
    {
        triggeredObjects = new List<GameObject>();
    }

    private void Update()
    {
        triggeredObjects.RemoveAll(triggeredObject => triggeredObject == null);
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

    public GameObject GetBossRoomEnterPoint()
    {
        foreach (var collidedObject in triggeredObjects)
        {
            if (collidedObject.CompareTag("BossDoorTrigger"))
            {
                return collidedObject;
            }
        }

        return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        triggeredObjects.Add(other.gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerCollidedWithTrigger(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        triggeredObjects.Remove(other.gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerLeftTrigger();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        ObjectCollided(other);
    }
}