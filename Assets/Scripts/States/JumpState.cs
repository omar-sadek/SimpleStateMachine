namespace StateEngine
{
    public class JumpState : JumpAbstractState
    {
        protected override void onJumpInput()
        {
            base.onJumpInput();
            SetState<DoubleJumpState>();
        }
    }
}
