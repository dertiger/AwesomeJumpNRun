using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDimension : MonoBehaviour
{

    [SerializeField] private InputManager inputManager;

    private Quaternion rotation;

    private void Start()
    {
        inputManager.ChangeDimension += OnChangeDimension;
        rotation = gameObject.transform.rotation;
    }

    private void OnChangeDimension()
    {
        rotation *= Quaternion.Euler(0, -90, 0);
    }


    // Update is called once per frame
	private void LateUpdate () {
		gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, rotation, 5 * Time.deltaTime);
	}
}
