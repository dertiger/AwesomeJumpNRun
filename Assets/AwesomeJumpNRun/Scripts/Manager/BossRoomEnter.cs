using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomEnter : MonoBehaviour {
    [SerializeField] InputManager inputManager;
    [SerializeField] Keys keys;

    public event Action EnterBossroom = delegate { };

	void Start () {
        inputManager.ChangeDimension += OnEnterBossRoom;
	}

    public void OnEnterBossRoom()
    {
        if (keys.MaxKeys == keys.CurrentKeys)
        {
            var dimensionChangeObject = GetComponent<CollidedObjects>().GetBossRoomEnterPoint();
            if (dimensionChangeObject != null)
            {
                EnterBossroom();
            }
        }
    }
}
