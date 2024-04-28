using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateReusableData
{
    public Vector2 MovementInput { get; set; }
    public float MovementSpeedModifier { get; set; } = 1f;
    
    private Vector3 _currentTargetRotation; //目標回転値
    private Vector3 _timeToReachTargetRotation; //回転にかかる時間
    private Vector3 _dampedTargetRotationCurrentVelocity; //回転速度
    private Vector3 _dampedTargetRotationPassedTime; //回転開始からの経過時間。
    
    public ref Vector3 CurrentTargetRotation
    {
        get
        {
            return ref _currentTargetRotation;
        }
    }

    public ref Vector3 TimeToReachTargetRotation
    {
        get
        {
            return ref _timeToReachTargetRotation;
        }
    }
    
    public ref Vector3 DampedTargetRotationCurrentVelocity
    {
        get
        {
            return ref _dampedTargetRotationCurrentVelocity;
        }
    }
    
    public ref Vector3 DampedTargetRotationPassedTime
    {
        get
        {
            return ref _dampedTargetRotationPassedTime;
        }
    }
}
