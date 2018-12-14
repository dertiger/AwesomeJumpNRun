using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPlattform : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(gameObject.transform);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        other.gameObject.transform.SetParent(null);
    }
}