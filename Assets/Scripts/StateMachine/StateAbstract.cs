using UnityEngine;
using UnityEngine.Events;

namespace StateEngine
{
    public abstract class StateAbstract : MonoBehaviour
    {
        protected StateMachineAbstract stateMachine = null;

        [SerializeField] UnityEvent onStateInit = null;
        [SerializeField] UnityEvent onStateEnter = null;
        [SerializeField] UnityEvent onStateExit = null;

        private float stateTime = 0.0f;

        #region STATE API

        /// <summary>
        /// Executed (ONCE) on Initialization.
        /// </summary>
        public virtual void InitState()
        {
            onStateInit?.Invoke();
        }

        /// <summary>
        /// Executed everytime you enter the state.
        /// </summary>
        public virtual void OnStateEnter()
        {
            onStateEnter?.Invoke();
            stateTime = 0.0f;
        }

        /// <summary>
        /// Executed every frame.
        /// </summary>
        public virtual void StateUpdate()
        {
            stateTime += Time.deltaTime;
        }

        /// <summary>
        /// Executed every physics frame.
        /// </summary>
        public virtual void StateLateUpdate()
        {
        }

        /// <summary>
        /// Executed every fixed frame.
        /// </summary>
        public virtual void StateFixedUpdate()
        {
        }

        /// <summary>
        /// Executed everytime your exit the state.
        /// </summary>
        public virtual void OnStateExit()
        {
            onStateExit?.Invoke();
            stateTime = 0.0f;
        }

        protected bool SetState<StateType>() where StateType : StateAbstract
        {
            if (null == stateMachine) return false;
            return stateMachine.SetState<StateType>();
        }

        #endregion

        #region GETTERS

        public float StateTime => stateTime;

        #endregion

        #region PUBLIC API

        public void InitializeState(StateMachineAbstract i_stateMachineAbstract)
        {
            stateMachine = i_stateMachineAbstract;

            InitState();
        }

        #endregion
    }
}