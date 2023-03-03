using UnityEngine;

public class IdleState : State
{
    [SerializeField] private State movementState = null;

    private float xInput;

    public override void OnStateEnter()
    {
        base.OnStateEnter();

        xInput = 0;
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();

        xInput = Mathf.Abs(Input.GetAxis("Horizontal"));
        if (xInput > Mathf.Epsilon)
        {
            stateMachine.SetState(movementState);
        }
    }

}
