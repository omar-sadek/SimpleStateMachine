using UnityEngine;

namespace StateEngine
{
    public class MovementState : CharacterAbstractState
    {
        [SerializeField] private float moveSpeed = 8f;
        
        protected override void onMoveInput(float i_xInput)
        {
            if (Mathf.Abs(i_xInput) < Mathf.Epsilon)
            {
                SetState<IdleState>();
                return;
            }
            
            Vector3 moveVector = new Vector2(i_xInput * moveSpeed * Time.fixedDeltaTime, 0);
            move(moveVector);
        }
        
        protected override void onJumpInput()
        {
            SetState<JumpState>();
        }
    }
}