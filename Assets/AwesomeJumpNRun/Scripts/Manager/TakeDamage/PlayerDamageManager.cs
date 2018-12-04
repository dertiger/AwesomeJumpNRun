using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageManager : DamageManager {
	protected override void Start () {
        base.Start();
        GetComponentInParent<CollidedObjects>().ObjectCollided += DamageManager_ObjectCollided;
	}
}