using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlattformManager : MonoBehaviour {
    [SerializeField]
    int moveSpeed;
    [SerializeField]
    string direction;

    bool collided;
    Vector3 move;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Move
        
        switch (direction) {
            case "x": move = new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
                break;
            case "y": move = new Vector3(0, moveSpeed, 0) * Time.deltaTime;
                break;
            case "z": move = new Vector3(0, 0, moveSpeed) * Time.deltaTime;
                break;
        }
        //Vector3 move = new Vector3(0, 0, moveSpeed) * Time.deltaTime;
        if (collided)
        {
            this.transform.position -= move;
        }
        else {
            this.transform.position += move;
        }
       
	}

    void OnCollisionEnter(Collision collision) {
        collided = !collided;
    }
}
