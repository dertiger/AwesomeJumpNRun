using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoPosition : ScriptableObject {
    public Vector3 position;
}

[CreateAssetMenu(fileName = "Player Position", menuName = "Positions/Player Position", order = 1)]
public class SoPlayerPosition : SoPosition
{
}

[CreateAssetMenu(fileName = "Camera Offset", menuName = "Positions/Camera Offset", order = 1)]
public class SoCameraOffset : SoPosition
{
    public void rotateRight()
    {
        rotate(new Vector3(0, -90, 0));
    }

    public void rotateLeft()
    {
        rotate(new Vector3(0, 90, 0));
    }

    public void rotate(Vector3 rotation)
    {
        position = Quaternion.Euler(rotation.x, rotation.y, rotation.z) * position;
    }
}