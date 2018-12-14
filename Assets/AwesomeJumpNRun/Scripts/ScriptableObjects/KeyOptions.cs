﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyOptions", menuName = "KeyOptions", order = 1)]
public class KeyOption : ScriptableObject
{
    public KeyCode JUMPKEY = KeyCode.Space;
    public KeyCode MOVERIGHT = KeyCode.RightArrow;
    public KeyCode MOVELEFT = KeyCode.LeftArrow;
    public KeyCode PERVIOUSCHAR = KeyCode.W;
    public KeyCode NEXTCHAR = KeyCode.Q;
    public KeyCode ENTERDIMENSION = KeyCode.F;
    public KeyCode SHOOT = KeyCode.D;
    public KeyCode RESTART = KeyCode.R;
}
