using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public event Action Jump = delegate { };
    public event Action<MoveDirection> Move = delegate { };
    public event Action ChangeDimension = delegate { };
    public event Action<Characters> SwitchedCharacter = delegate { };

    [SerializeField] KeyOption keyOption;
	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
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
        if (Input.GetKeyDown(keyOption.CHARACTER2))
        {
            SwitchedCharacter(Characters.CHARACTER2);
        }
        if (Input.GetKeyDown(keyOption.CHARACTER3))
        {
            SwitchedCharacter(Characters.CHARACTER3);
        }
    }

    private void CheckMove()
    {
        if (Input.GetKeyDown(keyOption.MOVERIGHT) || Input.GetKeyDown(keyOption.MOVELEFT) ||
            Input.GetKeyUp(keyOption.MOVERIGHT) || Input.GetKeyUp(keyOption.MOVELEFT))
        {
            if ((Input.GetKey(keyOption.MOVERIGHT) && Input.GetKey(keyOption.MOVELEFT)) ||
                (!Input.GetKey(keyOption.MOVERIGHT) && !Input.GetKey(keyOption.MOVELEFT)))
            {
                Move(MoveDirection.STOP);
            }
            else
            {
                if (Input.GetKey(keyOption.MOVERIGHT))
                {
                    Move(MoveDirection.RIGHT);
                }
                if (Input.GetKey(keyOption.MOVELEFT))
                {
                    Move(MoveDirection.LEFT);
                }
            }
        }
    }
}
