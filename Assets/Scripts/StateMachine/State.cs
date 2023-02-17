public class State
{
    public string name;
    protected StateMachine stateMachine;

    public State(string i_name, StateMachine i_stateMachine)
    {
        name = i_name;
        stateMachine = i_stateMachine;
        OnStateInit();
    }

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

}
