using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public event Action Jump = delegate { };
    public event Action MoveRight = delegate { };
    public event Action MoveLeft = delegate { };

    [SerializeField] KeyOption keyOption;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(keyOption.JUMPKEY))
        {
            Jump();
        }
        if (Input.GetKeyDown(keyOption.MOVERIGHT))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(keyOption.MOVELEFT))
        {
            MoveLeft();
        }
	}
}
