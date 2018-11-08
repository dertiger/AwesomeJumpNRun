using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementHandler{
    event Action<MoveDirection> Move;
}