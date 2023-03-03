using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    [SerializeField] private State initialState = null;

    private Dictionary<string, State> statesDictionary = null;
    [SerializeField] [HideInInspector] State currentState = null;

    #region UNITY & CORE

    protected virtual void Awake()
    {
        statesDictionary = new Dictionary<string, State>();
        initializeStates();
        currentState = getInitialState();
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
    public void SetState(string i_stateID)
    {
        State newState = getStateByID(i_stateID);
        changeState(newState);
    }

    #endregion

    #region PRIVATE API

    private void initializeStates()
    {
        State[] states = GetComponentsInChildren<State>(true);

        if (states == null) return;

        int length = states.Length;

        for (int i = 0; i < length; i++)
        {
            states[i].InitializeState(this);
            statesDictionary.Add(states[i].StateKey, states[i]);
        }
    }

    private State getInitialState()
    {
        if (initialState == null) 
        {
            Debug.LogError("State Machine Error: You Need to assign a default state");
            return null;
        }
        return initialState;
    }

    private void changeState(State i_state) 
    {
        currentState.OnStateExit();

        currentState = i_state;

        currentState.OnStateEnter();
    }

    private State getStateByID(string i_stateID)
    {
        return statesDictionary[i_stateID];
    }

    #endregion

    #region DEBUG

    public override string ToString()
    {
        return currentState != null ? currentState.ToString() : "NULL";
    }

    #endregion

}
