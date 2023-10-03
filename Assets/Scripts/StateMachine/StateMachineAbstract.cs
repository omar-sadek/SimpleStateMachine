using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachineAbstract : MonoBehaviour
{
    [SerializeField] private State initialState = null;

    private Dictionary<System.Type, State> stateDictionary = null;
    
    State currentState = null;
    State previousState = null;

    #region UNITY & CORE

    protected virtual void Awake()
    {
        stateDictionary = new Dictionary<System.Type, State>();
        
        currentState = getInitialState();
        if (currentState == null)
        {
            Debug.LogError("Cannot find states");
            return;
        }
        
        registerState(currentState);
        currentState.InitializeState(this);
        
        currentState?.EnterState();
    }

    private void Update()
    {
        currentState?.UpdateState();

    }

    private void FixedUpdate()
    {
        currentState?.StateFixedUpdate();

    }

    private void LateUpdate()
    {
        currentState?.LateUpdateState();
    }

    #endregion

    #region PUBLIC API

    public State CurrentState => currentState;

    public State PreviousState => previousState;

    public System.Type CurrentStateType => null == currentState ? null : currentState.GetType();

    public System.Type PreviousStateType => null == previousState ? null : previousState.GetType();
    
    public bool IsCurrentStateOfType<T>()
    {
        if (null == currentState) return false;
        return currentState is T;
    }

    public bool IsPreviousStateOfType<T>()
    {
        if (null == previousState) return false;
        return previousState is T;
    }

    public IReadOnlyList<System.Type> GetAllStateTypes()
    {
        if (stateDictionary == null) return null;
        
        List<System.Type> stateTypes = new List<Type>();
        int length = stateDictionary.Count;

        foreach ( KeyValuePair<System.Type, State> stateType in stateDictionary)
        {
            stateTypes.Add(stateType.Key);
        }

        return stateTypes;
    }

    /// <summary>
    /// Return State Type
    /// </summary>
    public State GetState<StateType>(bool i_searchInHierarchy = true) where StateType : State
    {
        if (null == stateDictionary) return null;

        State state = null;
        if (false == stateDictionary.TryGetValue(typeof(StateType), out state))
        {
            if (true == i_searchInHierarchy)
            {
                state = GetComponentInChildren<StateType>(true);
                if (null != state)
                {
                    registerState(state);
                    state.InitializeState(this);
                }
            }
        }
        return state;
    }

    /// <summary>
    /// Exits from the current state, Enter the passed state.
    /// </summary>
    public bool SetState(State i_state)
    {
        if (i_state == null) return false;
        
        changeState(i_state);
        return true;
    }
    
    /// <summary>
    /// Exits from the current state, Enter the passed state.
    /// </summary>
    public bool SetState<StateType>() where StateType : State
    {
        State state = GetState<StateType>(true);
        return SetState(state);
    }

    public void DebugEvents(string txt)
    {
        Debug.LogError(txt);
    }

    #endregion

    #region PRIVATE API

    private void registerState(State i_state)
    {
        if (i_state == null) return;

        if(stateDictionary == null) stateDictionary = new Dictionary<System.Type, State>();
        
        System.Type stateType = i_state.GetType();
        
        if (false == stateDictionary.ContainsKey(stateType)) 
            stateDictionary.Add(stateType, i_state);
    }

    private State getInitialState()
    {
        if (initialState == null) initialState = GetComponentInChildren<State>();
        return initialState;
    }

    private void changeState(State i_state) 
    {
        previousState = currentState;

        currentState.ExitState();

        currentState = i_state;

        currentState.EnterState();
    }

    #endregion
}
