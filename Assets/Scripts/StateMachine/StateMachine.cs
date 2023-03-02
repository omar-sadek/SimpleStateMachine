using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected Dictionary<string, State> StatesDictionary = null;
    [SerializeField] [HideInInspector] State currentState = null;

    #region UNITY & CORE

    protected virtual void Awake()
    {
        StatesDictionary = new Dictionary<string, State>();
        InitializeDictionary();
        currentState = GetInitialState();
    }

    private void Update()
    {
        currentState?.OnStateUpdate();

    }

    private void FixedUpdate()
    {
        currentState?.OnStateFixedUpdate();

    }

    private void LateUpdate()
    {
        currentState?.OnStateLateUpdate();
    }

    #endregion

    #region PROTECTED API

    protected abstract State GetInitialState();

    protected abstract void InitializeDictionary();

    #endregion

    #region PUBLIC API

    /// <summary>
    /// Exits from the current state, Enter the passed state.
    /// </summary>
    public void SetState(State i_state)
    {
        changeState(i_state);
    }
    /// <summary>
    /// Exits from the current state, Enter the passed state.
    /// </summary>
    public void SetState(string i_stateName)
    {
        State newState = getStateByName(i_stateName);
        changeState(newState);
    }

    #endregion

    #region PRIVATE API

    private void changeState(State i_state) 
    {
        currentState.OnStateExit();

        currentState = i_state;

        currentState.OnStateEnter();
    }

    private State getStateByName(string i_stateName)
    {
        return StatesDictionary[i_stateName];
    }

    #endregion

}
