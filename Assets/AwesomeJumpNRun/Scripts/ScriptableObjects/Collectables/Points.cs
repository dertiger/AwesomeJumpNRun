using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Points", menuName = "Points", order = 1)]
public class Points : ScriptableObject
{
    [SerializeField] private int points;

    public int CurrentPoints
    {
        get { return points; }
        set { points = value; }
    }

    public void AddPoints(int value)
    {
        CurrentPoints += value;
    }
}