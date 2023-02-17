using UnityEngine;

public class CharacterStateMachine : StateMachine
{
    [HideInInspector]
    public IdleState IdleState = null;
    [HideInInspector]
    public MovementState MovementState = null;

    [SerializeField] private float characterSpeed = 5.0f;

    #region UNITY & CORE

    protected override void Awake()
    {
        //On State Init
        IdleState = new IdleState(this);
        MovementState = new MovementState(this);

        base.Awake();
    }


    #endregion

    #region PROTECTED API

    protected override void InitializeDictionary()
    {
        StatesDictionary.Add("IdleState", IdleState);
        StatesDictionary.Add("MovementState", MovementState);
    }

    protected override State GetInitialState()
    {
        return IdleState;
    }

    #endregion

    #region GETTERS

    public float CharacterSpeed { get { return characterSpeed; } }

    #endregion

}
