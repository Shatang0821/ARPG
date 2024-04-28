using System;
using System.Collections.Generic;
using FrameWork.Factories;
using FrameWork.Manager;
using FrameWork.Utils;
using UnityEngine;

//MonoBehaviourを継承する意味がないかも
public class GameApp : UnitySingleton<GameApp>
{
    private PlayerManager _playerManager;
    public void InitGame()
    {
        Debug.Log("Enter Game!");

    }

}