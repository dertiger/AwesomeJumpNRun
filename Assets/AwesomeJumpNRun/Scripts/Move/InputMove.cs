using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMove : Move {

	// Use this for initialization
	public override void Start () {
        base.Start();
        GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>().Move += OnMove;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMove(MoveDirection direction)
    {
        moveDirection = direction;
    }
}
