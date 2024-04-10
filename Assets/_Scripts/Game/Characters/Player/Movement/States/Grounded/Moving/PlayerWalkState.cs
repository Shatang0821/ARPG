using UnityEngine.InputSystem;

public class PlayerWalkState : PlayerGroundedState
{
    public PlayerWalkState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region Istate Methods

    public override void Enter()
    {
        base.Enter();

        _stateMachine.ReusableData.MovementSpeedModifier = _movementData.WalkData.SpeedModifier;
    }

    #endregion
    
    /// <summary>
    /// 歩く状態から走る状態に切り替えたら
    /// </summary>
    /// <param name="context"></param>
    protected override void OnWalkToggleStarted(InputAction.CallbackContext context)
    {
        base.OnWalkToggleStarted(context);
        
        _stateMachine.ChangeState(_stateMachine.RunState);
    }
}