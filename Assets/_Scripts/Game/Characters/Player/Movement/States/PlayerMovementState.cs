using FrameWork.FSM;
using FrameWork.Utils;
using UnityEngine;

public class PlayerMovementState : IState
{
    protected PlayerMovementStateMachine _stateMachine;

    protected Vector2 _movementInput;
    protected PlayerMovementState(PlayerMovementStateMachine playerMovementStateMachine)
    {
        this._stateMachine = playerMovementStateMachine;
    }
    

    public virtual void Enter()
    {
        DebugLogger.Log("State:" + GetType().Name);
    }

    public virtual void Exit()
    {
        
    }
    
    public virtual void HandleInput()
    {
        ReadMovementInput();
        DebugLogger.Log(_movementInput);
    }

    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicsUpdate()
    {
        
    }

    #region Main Methods
    private void ReadMovementInput()
    {
        _movementInput = _stateMachine._player._input.Axis;
    }
    #endregion
}
