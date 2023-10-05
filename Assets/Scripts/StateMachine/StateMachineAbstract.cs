using System;
using System.Collections.Generic;
using UnityEngine;

namespace StateEngine
{
public delegate void StateMachineEvent();

public abstract class StateMachineAbstract : MonoBehaviour
{
    [SerializeField] private StateAbstract initialState = null;

    private Dictionary<System.Type, StateAbstract> stateDictionary = null;

    StateAbstract currentState = null;
    StateAbstract previousState = null;

    public StateMachineEvent OnStateChanged;

    #region UNITY & CORE

    protected virtual void Awake()
    {
        stateDictionary = new Dictionary<System.Type, StateAbstract>();

        currentState = getInitialState();
        if (currentState == null)
        {
            Debug.LogError("Cannot find states");
            return;
        }

        registerState(currentState);
        currentState.InitializeState(this);

        currentState.OnStateEnter();
    }

    private void Update()
    {
        currentState?.StateUpdate();

    }

    private void FixedUpdate()
    {
        currentState?.StateFixedUpdate();

    }

    private void LateUpdate()
    {
        currentState?.StateLateUpdate();
    }

    #endregion

    #region PUBLIC API

    public StateAbstract CurrentState => currentState;

    public StateAbstract PreviousState => previousState;

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

        foreach (KeyValuePair<System.Type, StateAbstract> stateType in stateDictionary)
        {
            stateTypes.Add(stateType.Key);
        }

        return stateTypes;
    }

    /// <summary>
    /// Return State Type
    /// </summary>
    public StateAbstract GetState<StateType>(bool i_searchInHierarchy = true) where StateType : StateAbstract
    {
        if (null == stateDictionary) return null;

        StateAbstract state = null;
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
    public bool SetState(StateAbstract i_state)
    {
        if (i_state == null) return false;
        if (i_state == currentState) return false;

        changeState(i_state);
        return true;
    }

    /// <summary>
    /// Exits from the current state, Enter the passed state.
    /// </summary>
    public bool SetState<StateType>() where StateType : StateAbstract
    {
        if (currentState is StateType) return false;
        
        StateAbstract state = GetState<StateType>(true);
        return SetState(state);
    }

    #endregion

    #region PRIVATE API

    private void registerState(StateAbstract i_state)
    {
        if (i_state == null) return;

        if (stateDictionary == null) stateDictionary = new Dictionary<System.Type, StateAbstract>();

        System.Type stateType = i_state.GetType();

        if (false == stateDictionary.ContainsKey(stateType))
            stateDictionary.Add(stateType, i_state);
    }

    private StateAbstract getInitialState()
    {
        if (initialState == null) initialState = GetComponentInChildren<StateAbstract>();
        return initialState;
    }

    private void changeState(StateAbstract i_state)
    {
        previousState = currentState;

        currentState.OnStateExit();

        currentState = i_state;

        currentState.OnStateEnter();

        OnStateChanged?.Invoke();
    }

    #endregion
}
}
