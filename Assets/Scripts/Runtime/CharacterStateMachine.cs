using UnityEngine;

public class CharacterStateMachine : StateMachineAbstract
{
    [SerializeField] private float characterSpeed = 5.0f;

    #region GETTERS

    public float CharacterSpeed => characterSpeed;

    #endregion
}
