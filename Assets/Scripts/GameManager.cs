using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


[System.Serializable]
public class GameData
{
    public int PointMultiplier;
    public float MultiplyTimer;
    public float MagnetTimer;
    public bool IsMagnetActive;
}

public class GameManager : Singleton<GameManager>
{
    private bool isGameStarted;
    
    public bool IsGameStarted { get { return isGameStarted; } private set { isGameStarted = value; } }

    public GameData GameData = new GameData();

    public void StartGame()
    {
        if (IsGameStarted)
            return;

        IsGameStarted = true;
        //EventManager.OnGameStart.Invoke();
    }

    public void EndGame()
    {
        if (!IsGameStarted)
            return;

        IsGameStarted = false;
        //EventManager.OnGameEnd.Invoke();
    }
}