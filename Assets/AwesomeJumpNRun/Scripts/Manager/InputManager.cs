using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event Action Jump = delegate { };
    public event Action<MoveDirection> Move = delegate { };
    public event Action ChangeDimension = delegate { };
    public event Action<Characters> SwitchedCharacter = delegate { };

    [SerializeField] KeyOption keyOption;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(keyOption.JUMPKEY))
        {
            Jump();
        }

        CheckMove();
        CheckCharacters();
        if (Input.GetKeyDown(keyOption.ENTERDIMENSION))
        {
            ChangeDimension();
        }
    }

    private void CheckCharacters()
    {
        if (Input.GetKeyDown(keyOption.CHARACTER1))
        {
            SwitchedCharacter(Characters.CHARACTER1);
        }
        else if (Input.GetKeyDown(keyOption.CHARACTER2))
        {
            SwitchedCharacter(Characters.CHARACTER2);
        }
        else if (Input.GetKeyDown(keyOption.CHARACTER3))
        {
            SwitchedCharacter(Characters.CHARACTER3);
        }
    }

    private void CheckMove()
    {
        if (Input.GetKey(keyOption.MOVERIGHT))
        {
            Move(MoveDirection.RIGHT);
        }
        else if (Input.GetKey(keyOption.MOVELEFT))
        {
            Move(MoveDirection.LEFT);
        }
        else
        {
            Move(MoveDirection.STOP);
        }
    }
}