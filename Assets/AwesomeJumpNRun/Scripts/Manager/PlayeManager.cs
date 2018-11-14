using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeManager : MonoBehaviour
{
    public event Action PlayerJumped = delegate { };
    public event Action PlayerDescending = delegate { };

    private Rigidbody rigbody;

    void Start()
    {
        rigbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(rigbody.velocity.y <= 0)
        {
            PlayerDescending();
        }
        else
        {
            PlayerJumped();
        }
    }
}
