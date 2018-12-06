using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectedHandler : MonoBehaviour
{
    [SerializeField] private Points points;

    public event Action<int> CoinCollected = delegate { };

    private void Start()
    {
        points.CurrentPoints = 0;
    }

    public void CoinGotCollected(int value)
    {
        points.AddPoints(value);
        CoinCollected(value);
    }
}