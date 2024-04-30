using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : PlayerGroundedState
{
    protected PlayerMovingState(string animName, PlayerStateMachine playerStateMachine, Animator animator) : base(animName, playerStateMachine, animator)
    {
    }
}
