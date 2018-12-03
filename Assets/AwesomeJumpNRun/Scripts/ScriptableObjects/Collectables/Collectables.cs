using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : ScriptableObject
{
    [SerializeField]
    private string name;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private double value;
    [SerializeField]
    private int size;
}
