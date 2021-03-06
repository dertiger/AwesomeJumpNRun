﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputJump : Jump
{
    protected override void Start()
    {
        base.Start();
        GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>().Jump += OnJump;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        var inputManager = GameObject.FindGameObjectWithTag("InputManager");
        if (inputManager != null)
        {
            inputManager.GetComponent<InputManager>().Jump -= OnJump;
        }
    }
}