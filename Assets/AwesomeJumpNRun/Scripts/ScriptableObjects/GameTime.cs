using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameTime", menuName = "GameTime", order = 1)]
public class GameTime : ScriptableObject
{
    [SerializeField] private int gameTime;

    public int CurrentGameTime
    {
        get { return gameTime; }
        set
        {
            gameTime = value;
            if (gameTime == 0)
            {
                GameTimeExpired();
            }
        }
    }

    public event Action GameTimeExpired = delegate { };

    public IEnumerator StartGameTimer()
    {
        while (CurrentGameTime > 0)
        {
            yield return new WaitForSeconds(1f);
            CurrentGameTime--;
        }
    }
}