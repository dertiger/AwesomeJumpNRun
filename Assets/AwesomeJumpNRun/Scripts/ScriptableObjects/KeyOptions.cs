using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyOptions", menuName = "KeyOptions", order = 1)]
public class KeyOption : ScriptableObject
{
    public KeyCode JUMPKEY = KeyCode.Space;
    public KeyCode MOVERIGHT = KeyCode.RightArrow;
    public KeyCode MOVELEFT = KeyCode.LeftArrow;
    public KeyCode CHARACTER1 = KeyCode.Q;
    public KeyCode CHARACTER2 = KeyCode.W;
    public KeyCode CHARACTER3 = KeyCode.E;
    public KeyCode ENTERDIMENSION = KeyCode.F;
    public KeyCode SHOOT = KeyCode.D;
}
