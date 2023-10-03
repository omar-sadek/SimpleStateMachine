using UnityEngine;
using UnityEngine.Events;

public class State : MonoBehaviour
{
    [SerializeField] protected string StateID = null;
    protected StateMachineAbstract stateMachine = null;

    [SerializeField] UnityEvent onStateInit = null;
    [SerializeField] UnityEvent onStateEnter = null;
    [SerializeField] UnityEvent onStateExit = null;

    #region STATE API

    /// <summary>
    /// Excuted (ONCE) on Initialization.
    /// </summary>
    public virtual void InitState()
    {
        onStateInit?.Invoke();
    }

    /// <summary>
    /// Excuted everytime you enter the state.
    /// </summary>
    public virtual void EnterState()
    {
        onStateEnter?.Invoke();
    }

    /// <summary>
    /// Excuted every frame.
    /// </summary>
    public virtual void UpdateState()
    {
    }

    /// <summary>
    /// Excuted every physics frame.
    /// </summary>
    public virtual void LateUpdateState()
    {
    }

    /// <summary>
    /// Excuted every fixed frame.
    /// </summary>
    public virtual void StateFixedUpdate()
    {
    }

    /// <summary>
    /// Excuted everytime your exit the state.
    /// </summary>
    public virtual void ExitState()
    {
        onStateExit?.Invoke();
    }
    
    protected bool SetState<StateType>() where StateType : State
    {
        if (null == stateMachine) return false;
        return stateMachine.SetState<StateType>();
    }

    #endregion

    public void InitializeState(StateMachineAbstract i_stateMachineAbstract)
    {
        stateMachine = i_stateMachineAbstract;

        InitState();
    }

    public string StateKey => StateID;

    #region DEBUG

    public override string ToString()
    {
        return StateID;
    }

    #endregion
}