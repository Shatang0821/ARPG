using FrameWork.FSM;
using FrameWork.Utils;
using UnityEngine;

public class PlayerMovementStateMachine : StateMachine
{
    public Player _player;
    public PlayerIdleState IdleState { get; }
    public PlayerWalkState WalkState { get; }
    public PlayerRunState RunState { get; }
    public PlayerSprintState SprintState { get; }

    public PlayerMovementStateMachine(Player player)
    {
        
        this._player = player;
        IdleState = new PlayerIdleState(this);

        WalkState = new PlayerWalkState(this);
        
        RunState = new PlayerRunState(this);
        
        SprintState = new PlayerSprintState(this);
        
        
    }
}
