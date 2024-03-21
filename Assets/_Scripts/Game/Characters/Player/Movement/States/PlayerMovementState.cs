using FrameWork.FSM;
using FrameWork.Utils;
using UnityEngine;

public class PlayerMovementState : IState
{
    public virtual void Enter()
    {
        DebugLogger.Log("State:" + GetType().Name);
    }

    public virtual void Exit()
    {
        
    }
    
    public virtual void LogicUpdate()
    {
        
    }

    public virtual void HandleInput()
    {
        
    }

    public virtual void PhysicsUpdate()
    {
        
    }
}
