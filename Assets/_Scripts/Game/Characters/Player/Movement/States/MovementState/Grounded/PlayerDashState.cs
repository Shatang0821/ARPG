using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDashState : PlayerGroundedState
{
    private PlayerDashData _dashData;

    private float _startTime;

    private int _consecutiveDashesUsed;//連続ダッシュのカウント
    
    public PlayerDashState(string animName, PlayerStateMachine playerStateMachine, Animator animator) : base(animName, playerStateMachine, animator)
    {
        _dashData = _movementData.DashData;
    }

    #region IState Methods
    public override void Enter()
    {
        _animTransitionDuration = 0.1f;
        base.Enter();
        
        _stateMachine.ReusableData.MovementSpeedModifier = _dashData.SpeedModifier;

        AddForceOnTransitionFromStatinaryState();

        UpdateConsecutiveDashes();

        _startTime = Time.time;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Time.time < _startTime + _dashData.DashDurationTime)
            return;
        if (_stateMachine.ReusableData.MovementInput == Vector2.zero)
        {
            _stateMachine.ChangeState(_stateMachine.IdleState);

            return;
        }
        
        _stateMachine.ChangeState(_stateMachine.SprintState);
    }

    // public override void OnAnimationTransitionEvent()
    // {
    //     if (_stateMachine.ReusableData.MovementInput == Vector2.zero)
    //     {
    //         _stateMachine.ChangeState(_stateMachine.IdleState);
    //
    //         return;
    //     }
    //     
    //     _stateMachine.ChangeState(_stateMachine.SprintState);
    // }

    #endregion

    #region Main Methods

    /// <summary>
    /// 正面に向けてダッシュ
    /// </summary>
    private void AddForceOnTransitionFromStatinaryState()
    {
        if (_stateMachine.ReusableData.MovementInput != Vector2.zero)
        {
            return;
        }

        Vector3 characterRotationDirection = _stateMachine.Player.transform.forward;

        characterRotationDirection.y = 0f;

        _stateMachine.Player.Rigidbody.velocity = characterRotationDirection * GetmovementSpeed();
    }
    
    /// <summary>
    /// dash制限数更新
    /// </summary>
    private void UpdateConsecutiveDashes()
    {
        // if (!IsConsecutive())
        // {
        //     _consecutiveDashesUsed = 0;
        // }
        //
        // ++_consecutiveDashesUsed;

        // if (_consecutiveDashesUsed == _dashData.ConsecutiveDashedLimitAmount)
        // {
        //     _consecutiveDashesUsed = 0;
        //     
        //     _stateMachine.Player.Input.DisableActionFor(_stateMachine.Player.Input._inputActions.Player.Dash,_dashData.DashLimitReachedCooldown);
        // }
    }

    /// <summary>
    /// 連続ダッシュのチェック
    /// </summary>
    /// <returns></returns>
    // private bool IsConsecutive()
    // {
    //     return Time.time < _startTime + _dashData.TimeToBeConsideredConsecutive;
    // }

    #endregion

    #region Input Methods

    protected override void OnDashStarted(InputAction.CallbackContext context)
    {
        
    }

    #endregion
}