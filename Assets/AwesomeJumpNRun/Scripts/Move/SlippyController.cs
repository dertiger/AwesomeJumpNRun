using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlippyController : MonoBehaviour {

    public float thrust;
    public Rigidbody rb;

    void Start()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody>();
        thrust = 20.0f;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            
            rb.AddForce(0, 0, thrust, ForceMode.Impulse);
        }
       
    }

}
