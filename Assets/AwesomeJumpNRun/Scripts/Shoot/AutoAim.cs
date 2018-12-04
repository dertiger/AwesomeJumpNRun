using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour {
    [SerializeField] private Transform shootPosition;
    [SerializeField] private PlayerPosition enemyPosition;
	// Update is called once per frame
	void LateUpdate () {
        shootPosition.LookAt(enemyPosition.playerPosition);
        //shootPosition.rotation = Quaternion.Euler(shootPosition.rotation.eulerAngles.x, 0, shootPosition.rotation.eulerAngles.z);
	}
}
