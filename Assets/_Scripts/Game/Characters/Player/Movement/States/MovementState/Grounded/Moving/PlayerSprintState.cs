using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSprintState : PlayerMovingState
{
    private PlayerSprintData _sprintData;

    private bool _keepSprinting;

    private float _startTime;
    public PlayerSprintState(string animName, PlayerStateMachine playerStateMachine, Animator animator) : base(animName, playerStateMachine, animator)
    {
        _sprintData = _movementData.SprintData;
    }

    #region IState Methods
    public override void Enter()
    {
        _animTransitionDuration = 0.1f;
        base.Enter();
        _startTime = Time.time; 

        _stateMachine.ReusableData.MovementSpeedModifier = _sprintData.SpeedModifier;
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
