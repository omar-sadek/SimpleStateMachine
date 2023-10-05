using System;
using UnityEngine;

namespace StateEngine
{
    public abstract class JumpAbstractState : CharacterAbstractState
    {
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private Transform groundChecker = null;
        
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            jump(jumpForce);
        }

        public override void StateFixedUpdate()
        {
            base.StateFixedUpdate();
            
            if (groundChecker == null) return;

            // a hacky(bad) way to skip some frames before detecting the ground just for the sake of the demo
            if (StateTime < 0.2f) return;
            
            
            RaycastHit2D hit = Physics2D.Raycast(groundChecker.position, Vector2.down, 0.1f);
            if (hit.collider == null) return;

            SetState<IdleState>();
        }

        protected override void onMoveInput(float i_xInput)
        {
            Vector3 moveVector = new Vector2(i_xInput * 5f * Time.fixedDeltaTime, 0);
            move(moveVector);
        }

        protected override void onJumpInput()
        {
        }
    }
}
