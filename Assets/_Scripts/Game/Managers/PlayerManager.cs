using FrameWork.Manager;
using FrameWork.Utils;
using UnityEngine;

public class PlayerManager : MonoBehaviour,IManager
{
    private Player _player;
    
    private PlayerMovementStateMachine _playerMovementStateMachine;
    public void Init()
    {
        _player = new Player();
        _playerMovementStateMachine = new PlayerMovementStateMachine(_player);
        DebugLogger.Log("Init");
        _player.SpawnPlayer(new Vector3(0,1,0));
    }

    public void Enter()
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