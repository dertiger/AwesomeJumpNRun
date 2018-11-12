using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Position : ScriptableObject
{
    [SerializeField] private Vector3 position;

    public Vector3 ObjectPosition
    {
        get { return position; }
        set { position = value; }
    }
}

[CreateAssetMenu(fileName = "PlayerPosition", menuName = "Positions/Player Position", order = 1)]
public class PlayerPosition : Position
{
}

[CreateAssetMenu(fileName = "CameraOffset", menuName = "Positions/Camera Offset", order = 1)]
public class CameraOffset : Position
{
}