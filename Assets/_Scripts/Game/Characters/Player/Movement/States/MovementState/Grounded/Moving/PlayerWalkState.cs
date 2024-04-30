using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerWalkState : PlayerMovingState
{
    public PlayerWalkState(string animName, PlayerStateMachine playerStateMachine, Animator animator) : base(
        animName, playerStateMachine, animator)
    {
    }

    #region IState Methods

    public override void Enter()
    {
        _animTransitionDuration = 0.1f;
        base.Enter();

        _stateMachine.ReusableData.MovementSpeedModifier = _movementData.WalkData.SpeedModifier;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (_stateMachine.ReusableData.MovementInput == Vector2.zero)
        {
            _stateMachine.ChangeState(_stateMachine.IdleState);
            return;
        }
    }

    #endregion
}