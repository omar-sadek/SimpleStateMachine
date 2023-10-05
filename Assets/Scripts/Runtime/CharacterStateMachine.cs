using UnityEngine;
using UnityEngine.Serialization;

namespace StateEngine
{
    public class CharacterStateMachine : StateMachineAbstract
    {
        [SerializeField] private Rigidbody2D physicalBody = null;

        #region GETTERS

        public Rigidbody2D PhysicalBody => physicalBody;

        #endregion
    }
}
