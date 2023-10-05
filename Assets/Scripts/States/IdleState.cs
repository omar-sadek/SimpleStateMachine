using UnityEngine;

namespace StateEngine
{
    public class IdleState : CharacterAbstractState
    {
        protected override void onMoveInput(float i_xInput)
        {
            if (Mathf.Abs(i_xInput) > Mathf.Epsilon)
            {
                SetState<MovementState>();
            }
        }
        
        protected override void onJumpInput()
        {
            SetState<JumpState>();
        }
    }
}