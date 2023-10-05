using System;
using UnityEngine;

namespace StateEngine
{
    public abstract class CharacterAbstractState : StateAbstract
    {
        [SerializeField] protected bool canMove = false;
        [SerializeField] protected bool canJump = false;
        
        private CharacterStateMachine characterSM = null;
        
        protected Rigidbody2D physicalBody = null;

        private float xInput = 0f;

        #region STATE API

        public override void InitState()
        {
            base.InitState();

            characterSM = (CharacterStateMachine)stateMachine;
            physicalBody = characterSM.PhysicalBody;
        }

        public override void StateUpdate()
        {
            base.StateUpdate();

            if (canMove) xInput = Input.GetAxis("Horizontal");
            if (canJump && Input.GetKeyDown(KeyCode.Space)) onJumpInput();
        }

        public override void StateFixedUpdate()
        {
            base.StateFixedUpdate();
            if(canMove) onMoveInput(xInput);
        }

        #endregion

        #region Abstract API

        protected abstract void onMoveInput(float i_xInput);
        
        protected abstract void onJumpInput();

        #endregion

        #region PROTECTED API

        protected void move(Vector2 i_moveVector)
        {
            physicalBody.transform.position += (Vector3)i_moveVector;
        }

        protected void jump(float i_jumpForce)
        {
            physicalBody.AddForce(Vector2.up * i_jumpForce, ForceMode2D.Impulse);
        }

        #endregion
    }
}