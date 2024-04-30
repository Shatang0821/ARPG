using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundedState : PlayerMovementState
{
    public PlayerGroundedState(string animName, PlayerStateMachine playerStateMachine, Animator animator) : base(animName, playerStateMachine, animator)
    {
    }
    
    
    
    #region Reusable Methods
    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();
        _stateMachine.Player.Input._inputActions.Player.Dash.started += OnDashStarted;
    }
    protected override void RemoveInputActionsCallbacks()
    {
        base.RemoveInputActionsCallbacks();
        
        _stateMachine.Player.Input._inputActions.Player.Dash.started += OnDashStarted;
    }
    protected virtual void OnDashStarted(InputAction.CallbackContext context)
    {
        _stateMachine.ChangeState(_stateMachine.DashState);
    }

    #endregion
}
