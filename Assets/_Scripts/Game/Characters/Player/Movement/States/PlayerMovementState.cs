using FrameWork.FSM;
using FrameWork.Utils;
using UnityEngine;

public class PlayerMovementState : IState
{
    protected PlayerMovementStateMachine _stateMachine;
    protected PlayerInput _input;
    protected Rigidbody _rigidbody;
    protected Vector2 _movementInput;
    private Vector3 _movementDirection;
    
    protected float _baseSpeed = 5f;
    protected float _speedModifier = 1f;
    
    protected PlayerMovementState(PlayerMovementStateMachine playerMovementStateMachine)
    {
        this._stateMachine = playerMovementStateMachine;
        _input = _stateMachine.Player.Input;
        _rigidbody = _stateMachine.Player.Rigidbody;
    }

    #region StateMethod

    public virtual void Enter()
    {
        DebugLogger.Log("State:" + GetType().Name);
    }

    public virtual void Exit()
    {
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
    /// 入力取得
    /// </summary>
    private void ReadMovementInput()
    {
        _movementInput = _input.Axis;
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        if (_movementInput == Vector2.zero || _speedModifier == 0f) return;

        _movementDirection = GetMovementInputDirection();

        float movementSpeed = GetmovementSpeed();

        Vector3 currentPlayerHorizontalVelocity = GetPlayerHorizontalVelocity();
        _rigidbody.AddForce(movementSpeed * _movementDirection - currentPlayerHorizontalVelocity,ForceMode.VelocityChange);
    }

    

    #endregion

    #region 再利用できる

    /// <summary>
    /// 移動方向を取得
    /// </summary>
    /// <returns></returns>
    protected Vector3 GetMovementInputDirection()
    {
        return new Vector3(_movementInput.x, 0, _movementInput.y);
    }

    /// <summary>
    /// 速度計算
    /// </summary>
    /// <returns></returns>
    protected float GetmovementSpeed()
    {
        return _baseSpeed * _speedModifier;
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
    #endregion
}