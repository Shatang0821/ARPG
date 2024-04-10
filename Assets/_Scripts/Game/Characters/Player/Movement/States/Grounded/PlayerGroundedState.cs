using UnityEngine.InputSystem;

public class PlayerGroundedState : PlayerMovementState
{
    protected PlayerGroundedState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }
    
    #region Reusable Methods
    
    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();
        
        _input._inputActions.Player.Movement.canceled += OnMovementCanceled;
    }
    
    protected override void RemoveInputActionsCallbacks()
    {
        base.RemoveInputActionsCallbacks();
        
        _input._inputActions.Player.Movement.canceled -= OnMovementCanceled;
    }
    
    protected virtual void OnMove()
    {
        if (_stateMachine.ReusableData.ShouldWalk)
        {
            _stateMachine.ChangeState(_stateMachine.WalkState);
            return;
        }
        
        _stateMachine.ChangeState(_stateMachine.RunState);
    }
    #endregion
    
    #region Input Methods
    
    /// <summary>
    /// 移動入力の中止イベント
    /// </summary>
    /// <param name="context"></param>
    protected virtual void OnMovementCanceled(InputAction.CallbackContext context)
    {
        _stateMachine.ChangeState(_stateMachine.IdleState);
    }
    #endregion
}
