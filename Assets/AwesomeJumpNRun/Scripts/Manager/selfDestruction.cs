using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

}
