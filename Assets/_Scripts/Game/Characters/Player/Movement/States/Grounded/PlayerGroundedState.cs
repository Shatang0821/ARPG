using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundedState : PlayerMovementState
{
    public PlayerGroundedState(string animName, PlayerStateMachine playerStateMachine, Animator animator) : base(animName, playerStateMachine, animator)
    {
    }
    
    
    
    #region Reusable Methods

    protected virtual void OnWalk()
    {
        _stateMachine.ChangeState(_stateMachine.WalkState);
    }
    protected virtual void OnMove()
    {
        _stateMachine.ChangeState(_stateMachine.SprintState);
    }

    protected virtual void OnIdle()
    {
        _stateMachine.ChangeState(_stateMachine.IdleState);
    }
    #endregion

}
