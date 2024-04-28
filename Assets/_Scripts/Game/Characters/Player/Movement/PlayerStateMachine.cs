using FrameWork.FSM;
using FrameWork.Utils;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; private set; }
    public PlayerStateReusableData ReusableData { get;}
    public PlayerIdleState IdleState { get; }
    public PlayerDashState DashState { get; }
    public PlayerSprintState SprintState { get; }
    public PlayerWalkState WalkState { get; }

    public PlayerStateMachine(Player player,Animator animator)
    {
        this.Player = player;
        ReusableData = new PlayerStateReusableData();
        IdleState = new PlayerIdleState("Idle",this,animator);
        
        DashState = new PlayerDashState("Run",this,animator);
        
        SprintState = new PlayerSprintState("Run",this,animator);

        WalkState = new PlayerWalkState("Walk", this, animator);
        
        

    }
}
