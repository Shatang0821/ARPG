using FrameWork.FSM;
using FrameWork.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤーの移動状態を管理するクラス。
/// 入力に基づいて移動と回転を実行し、状態マシンパターンの一部として機能します。
/// </summary>
public class PlayerMovementState : IState
{
    protected PlayerMovementStateMachine _stateMachine;
    protected PlayerInput _input;
    protected Rigidbody _rigidbody;

    protected PlayerGroundedData _movementData;

    protected PlayerMovementState(PlayerMovementStateMachine playerMovementStateMachine)
    {
        this._stateMachine = playerMovementStateMachine;
        _input = _stateMachine.Player.Input;
        _rigidbody = _stateMachine.Player.Rigidbody;

        _movementData = _stateMachine.Player.Data.GroundedData;

        InitializeData();
    }

    /// <summary>
    /// 回転に関するデータを初期化します
    /// </summary>
    private void InitializeData()
    {
        _stateMachine.ReusableData.TimeToReachTargetRotation = _movementData.BaseRotationData.TargetRotationReachTime;
    }

    #region StateMethod

    public virtual void Enter()
    {
        DebugLogger.Log("State:" + GetType().Name);

        AddInputActionsCallbacks();
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallbacks();
    }


    public virtual void HandleInput()
    {
        ReadMovementInput();
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicsUpdate()
    {
        Move();
    }

    #endregion


    #region Main Methods

    /// <summary>
    /// プレイヤーの入力を読み取り、移動入力を更新します
    /// </summary>
    private void ReadMovementInput()
    {
        _stateMachine.ReusableData.MovementInput = _input.Axis;
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        if (_stateMachine.ReusableData.MovementInput == Vector2.zero ||
            _stateMachine.ReusableData.MovementSpeedModifier == 0f) return;

        var movementDirection = GetMovementInputDirection();

        float targetRotationYAngle = Rotate(movementDirection);

        Vector3 targetRotationDirection = GetTargetRotationDirection(targetRotationYAngle);

        float movementSpeed = GetmovementSpeed();

        // 現在の水平方向の速度から、必要な力を計算し適用します。
        Vector3 currentPlayerHorizontalVelocity = GetPlayerHorizontalVelocity();
        _rigidbody.AddForce(targetRotationDirection * movementSpeed - currentPlayerHorizontalVelocity,
            ForceMode.VelocityChange);
    }

    /// <summary>
    /// 指定した方向に対してプレイヤーを回転させます。カメラの回転も考慮します。
    /// </summary>
    /// <param name="direction">回転させる方向</param>
    /// <returns>回転後のY軸角度</returns>
    private float Rotate(Vector3 direction)
    {
        var directionAngle = UpdateTargetRotation(direction);

        RotateTowardsTargetRotation();
        return directionAngle;
    }

    /// <summary>
    /// カメラ回転角度を加算する
    /// </summary>
    /// <param name="angel"></param>
    /// <returns></returns>
    private float AddCameraRotationToAngle(float angel)
    {
        angel += _stateMachine.Player.MainCameraTransform.eulerAngles.y;

        if (angel > 360f)
        {
            angel -= 360f;
        }

        return angel;
    }

    /// <summary>
    /// 角度を計算する
    /// </summary>
    /// <param name="direction">入力方向ベクトル</param>
    /// <returns></returns>
    private float GetDirectionAngle(Vector3 direction)
    {
        float directionAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        if (directionAngle < 0f)
        {
            directionAngle += 360f;
        }

        return directionAngle;
    }


    private void UpdateTargetRotationData(float targetAngle)
    {
        _stateMachine.ReusableData.CurrentTargetRotation.y = targetAngle;

        _stateMachine.ReusableData.DampedTargetRotationPassedTime.y = 0f;
    }

    #endregion

    #region 再利用できる

    /// <summary>
    /// 移動方向を取得
    /// </summary>
    /// <returns></returns>
    protected Vector3 GetMovementInputDirection()
    {
        return new Vector3(_stateMachine.ReusableData.MovementInput.x, 0, _stateMachine.ReusableData.MovementInput.y);
    }

    /// <summary>
    /// 速度計算
    /// </summary>
    /// <returns></returns>
    protected float GetmovementSpeed()
    {
        return _movementData.BaseSpeed * _stateMachine.ReusableData.MovementSpeedModifier;
    }

    /// <summary>
    /// 速度更新
    /// </summary>
    /// <returns></returns>
    protected Vector3 GetPlayerHorizontalVelocity()
    {
        Vector3 playerHorizontalVelocity = _rigidbody.velocity;

        playerHorizontalVelocity.y = 0f;

        return playerHorizontalVelocity;
    }

    /// <summary>
    /// 目標の回転方向へ滑らかに回転させます。
    /// </summary>
    private void RotateTowardsTargetRotation()
    {
        float currentYAngle = _rigidbody.rotation.eulerAngles.y;

        if (currentYAngle == _stateMachine.ReusableData.CurrentTargetRotation.y)
        {
            return;
        }

        float smoothedYAngle = Mathf.SmoothDampAngle(currentYAngle, _stateMachine.ReusableData.CurrentTargetRotation.y,
            ref _stateMachine.ReusableData.DampedTargetRotationCurrentVelocity.y,
            _stateMachine.ReusableData.TimeToReachTargetRotation.y);

        _stateMachine.ReusableData.DampedTargetRotationPassedTime.y += Time.deltaTime;

        Quaternion targetRotation = Quaternion.Euler(0f, smoothedYAngle, 0f);

        _rigidbody.MoveRotation(targetRotation);
    }

    /// <summary>
    /// プレイヤーの移動方向に基づく目標回転角度を設定します
    /// </summary>
    /// <param name="direction">移動方向</param>
    /// <param name="shouldConsiderCameraRotation">カメラ角度を考慮するか</param>
    /// <returns></returns>
    protected float UpdateTargetRotation(Vector3 direction, bool shouldConsiderCameraRotation = true)
    {
        float directionAngle = GetDirectionAngle(direction);

        if (shouldConsiderCameraRotation)
        {
            directionAngle = AddCameraRotationToAngle(directionAngle);
        }

        if (directionAngle != _stateMachine.ReusableData.CurrentTargetRotation.y)
        {
            UpdateTargetRotationData(directionAngle);
        }

        return directionAngle;
    }

    /// <summary>
    /// 移動方向ベクトルを計算
    /// </summary>
    /// <param name="targetAngle"></param>
    /// <returns></returns>
    protected Vector3 GetTargetRotationDirection(float targetAngle)
    {
        return Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
    }

    /// <summary>
    /// 速度のリセット
    /// </summary>
    protected void ResetVelocity()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    /// <summary>
    /// 入力イベントの登録
    /// </summary>
    protected virtual void AddInputActionsCallbacks()
    {
        _input._inputActions.Player.WalkToggle.started += OnWalkToggleStarted;
    }

    /// <summary>
    /// 入力イベントの解除
    /// </summary>
    protected virtual void RemoveInputActionsCallbacks()
    {
        _input._inputActions.Player.WalkToggle.started -= OnWalkToggleStarted;
    }

    #endregion

    #region Input Methods

    /// <summary>
    /// 歩く状態の切り替え
    /// </summary>
    /// <param name="context"></param>
    protected virtual void OnWalkToggleStarted(InputAction.CallbackContext context)
    {
        _stateMachine.ReusableData.ShouldWalk = !_stateMachine.ReusableData.ShouldWalk;
        Debug.Log(_stateMachine.ReusableData.ShouldWalk);
    }

    #endregion
}