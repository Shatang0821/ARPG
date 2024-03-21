using System.Collections.Generic;
using FrameWork.Factories;
using FrameWork.Manager;
using FrameWork.Utils;
using UnityEngine;

//MonoBehaviourを継承する意味がないかも
public class GameApp : UnitySingleton<GameApp>
{
    [SerializeField] private List<IManager> _managers = new List<IManager>();

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

    private void LogicUpdate()
    {
        for (var i = 0; i < _managers.Count; i++)
        {
            _managers[i].LogicUpdate();
        }
    }

    /// <summary>
    /// マネージャーのオブジェクトを生成
    /// </summary>
    private void InitMgr()
    {
        //GeneratorPoolMgr();

        _managers.Add(ManagerFactory.Instance.CreateManager<PoolManager>(this.transform));
        _managers.Add(ManagerFactory.Instance.CreateManager<PlayerManager>(this.transform));
        foreach (var manager in _managers)
        {
            DebugLogger.Log(manager.GetType().Name);
        }
        //..
        //..
    }
}