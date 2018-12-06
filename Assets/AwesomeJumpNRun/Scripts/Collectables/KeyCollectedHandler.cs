using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollectedHandler : MonoBehaviour
{
    [SerializeField] private Keys keys;

    public event Action KeyCollected = delegate { };

    private void Start()
    {
        keys.CurrentKeys = 0;
    }

    public void KeyGotCollected()
    {
        keys.KeyCollected();
        KeyCollected();
    }
}