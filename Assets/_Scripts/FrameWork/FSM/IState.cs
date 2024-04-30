namespace FrameWork.FSM
{
    public interface IState
    {
        public void Enter();
        
        public void Exit();
        
        public void HandleInput();
        
        public void LogicUpdate();
        
        public void PhysicsUpdate();

        public void OnAnimationEnterEvent();

        public void OnAnimationExitEvent();

        public void OnAnimationTransitionEvent();
    }
}
