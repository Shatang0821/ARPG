using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSprintState : PlayerMovingState
{
    public PlayerSprintState(string animName, PlayerStateMachine playerStateMachine, Animator animator) : base(animName, playerStateMachine, animator)
    {
    }

    #region IState Methods
    public override void Enter()
    {
        _animTransitionDuration = 0.1f;
        base.Enter();

        _stateMachine.ReusableData.MovementSpeedModifier = _movementData.RunData.SpeedModifier;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(_stateMachine.ReusableData.MovementInput == Vector2.zero)
        {
            OnIdle();
            return;
        }
    }

    #endregion
    

    
}
