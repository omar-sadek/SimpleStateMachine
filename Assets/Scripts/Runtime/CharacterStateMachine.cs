using UnityEngine;

public class CharacterStateMachine : StateMachine
{
    [SerializeField] private float characterSpeed = 5.0f;

    #region GETTERS

    public float CharacterSpeed => characterSpeed;

    #endregion

}
