using Unity.VisualScripting;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region IState Methods
    public override void Enter()
    {
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