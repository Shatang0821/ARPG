using FrameWork.FSM;
using UnityEngine;

public class PlayerMovementStateMachine : StateMachine
{
    public PlayerIdleState IdleState { get; }
    public PlayerWalkState WalkState { get; }
    public PlayerRunState RunState { get; }
    public PlayerSprintState SprintState { get; }

    public PlayerMovementStateMachine()
    {
        IdleState = new PlayerIdleState();
        
        WalkState = new PlayerWalkState();
        RunState = new PlayerRunState();
        SprintState = new PlayerSprintState();
    }
}
