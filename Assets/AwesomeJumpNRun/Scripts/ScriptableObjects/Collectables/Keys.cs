using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keys", menuName = "Keys", order = 1)]
public class Keys : ScriptableObject
{
    [SerializeField] private int keys;
    [SerializeField] private int maxKeys;

    public int CurrentKeys
    {
        get { return keys; }
        set { keys = value; }
    }

    public int MaxKeys
    {
        get { return maxKeys; }
        set { maxKeys = value; }
    }

    public void KeyCollected()
    {
        CurrentKeys += 1;
    }
}