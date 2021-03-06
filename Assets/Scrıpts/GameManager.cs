﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum GameStates
{
    Idle,
    Playing,
    Win,
    Fail
}

public class GameManager : MonoBehaviour
{
    public static GameManager main;
    public GameStates currentState;
    void Awake()
    {
        main = this;
    }
    private void Start()
    {

        ChangeGameState(GameStates.Idle);
    }
    public void ChangeGameState(GameStates state)
    {
        currentState = state;
        switch (state)
        {
            case GameStates.Idle:
                UIManager.main.ChangeGameUI(Screens.MainMenu);
                break;
            case GameStates.Playing:
                UIManager.main.ChangeGameUI(Screens.Ingame);
                break;
            case GameStates.Win:
                UIManager.main.ChangeGameUI(Screens.Win);
                break;
            case GameStates.Fail:
                StopCoroutine(LevelManager.main.levelCor);
                UIManager.main.ChangeGameUI(Screens.Fail);
                break;
            default:
                break;
        }
    }

}
