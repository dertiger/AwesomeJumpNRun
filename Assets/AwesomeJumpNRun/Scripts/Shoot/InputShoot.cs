using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputShoot : Shoot
{
    protected override void Start()
    {
        base.Start();
        GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>().Shoot += OnShoot;
    }

    private void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>().Shoot -= OnShoot;
    }
}
