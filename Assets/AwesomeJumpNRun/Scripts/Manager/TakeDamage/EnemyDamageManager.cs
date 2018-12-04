using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageManager : DamageManager {
    protected override void Start()
    {
        base.Start();
        GetComponent<CollidedObjects>().ObjectCollided += DamageManager_ObjectCollided;
    }
}
