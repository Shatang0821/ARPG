using Unity.VisualScripting;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(string animName, PlayerStateMachine playerStateMachine, Animator animator) : base(animName, playerStateMachine, animator)
    {
    }

    #region IState Methods
    public override void Enter()
    {
        _animTransitionDuration = 0.25f;
        base.Enter();
        
        _stateMachine.ReusableData.MovementSpeedModifier = 0f;

        ResetVelocity();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (_stateMachine.ReusableData.MovementInput == Vector2.zero)
        {
            return;
        }

        OnMove();
    }

    
    #endregion

 
}