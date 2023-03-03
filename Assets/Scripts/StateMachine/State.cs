using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] protected string StateID = null;
    protected StateMachine stateMachine = null;

    #region STATE API

    /// <summary>
    /// Excuted (ONCE) on Initialization.
    /// </summary>
    public virtual void OnStateInit() { }

    /// <summary>
    /// Excuted everytime you enter the state.
    /// </summary>
    public virtual void OnStateEnter() { }

    /// <summary>
    /// Excuted every frame.
    /// </summary>
    public virtual void OnStateUpdate() { }

    /// <summary>
    /// Excuted every physics frame.
    /// </summary>
    public virtual void OnStateLateUpdate() { }

    /// <summary>
    /// Excuted every fixed frame.
    /// </summary>
    public virtual void OnStateFixedUpdate() { }

    /// <summary>
    /// Excuted everytime your exit the state.
    /// </summary>
    public virtual void OnStateExit() { }

    #endregion

    public void InitializeState(StateMachine i_stateMachine)
    {
        stateMachine = i_stateMachine;

        OnStateInit();
    }

    public string StateKey => StateID;

    #region DEBUG

    public override string ToString()
    {
        return StateID;
    }

    #endregion

}
