using FrameWork.Manager;
using UnityEngine;

public class Player
{
    private readonly string PREFABROOT = "Prefabs/Player/Player.prefab";
    private GameObject _playerPrefab;

    private PlayerMovementStateMachine _playerMovementStateMachine;
    
    public Player()
    {
        _playerMovementStateMachine = new PlayerMovementStateMachine();
    }

    public void SpawnPlayer(Vector3 spawnPoint)
    {
        // プレファブを指定された位置と回転でインスタンス化
        _playerPrefab = GameObject.Instantiate(ResManager.Instance.GetAssetCache<GameObject>(PREFABROOT), spawnPoint, Quaternion.identity);
    }

    public void Init()
    {
        _playerMovementStateMachine.ChangeState(_playerMovementStateMachine.IdleState);
    }

    public void LogicUpdate()
    {
        _playerMovementStateMachine.HandleInput();
        _playerMovementStateMachine.LogicUpdate();
    }

    public void PhysicsUpdate()
    {
        _playerMovementStateMachine.PhysicsUpdate();
    }
}
