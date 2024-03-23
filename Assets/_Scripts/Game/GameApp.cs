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
        this.EnterMainScene();
    }

    /// <summary>
    /// ゲームシーンに入る
    /// </summary>
    private void EnterMainScene()
    {
        //マップの生成...
        /* string mapName = "Maps/Game.prefab";
         GameObject mapPrefab = ResManager.Instance.GetAssetCache<GameObject>(mapName);
         GameObject map = GameObject.Instantiate(mapPrefab);
         */
        //マネージャーの生成
        InitMgr();

        //UIの生成
        //UIManager.Instance.ShowUI("UIHome");
    }

    private void Start()
    {
        _playerManager.Enter();
    }

    private void Update()
    {
        _playerManager.LogicUpdate();
    }

    private void FixedUpdate()
    {
        _playerManager.PhysicsUpdate();
    }

    /// <summary>
    /// マネージャーのオブジェクトを生成
    /// </summary>
    private void InitMgr()
    {
        //GeneratorPoolMgr();

        
        _playerManager = ManagerFactory.Instance.CreateManager<PlayerManager>();
        
    }
}