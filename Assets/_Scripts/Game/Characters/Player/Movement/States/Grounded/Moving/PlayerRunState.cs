using UnityEngine.InputSystem;

public class PlayerRunState : PlayerGroundedState
{
    public PlayerRunState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region IState Methods
    public override void Enter()
    {
        base.Enter();

        _stateMachine.ReusableData.MovementSpeedModifier = _movementData.RunData.SpeedModifier;
    }
    #endregion
    
    /// <summary>
    /// 歩く状態から走る状態に切り替えたら
    /// </summary>
    /// <param name="context"></param>
    protected override void OnWalkToggleStarted(InputAction.CallbackContext context)
    {
        base.OnWalkToggleStarted(context);
        
        _stateMachine.ChangeState(_stateMachine.WalkState);
    }
}
