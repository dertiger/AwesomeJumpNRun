using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CoinData", menuName= "Coin Data", order = 51)]
public class CoinData : ScriptableObject
{
    [SerializeField]
    private int value;

    public int Value
    {
        get
        {
            return value;
        }
    }
}



