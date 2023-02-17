using UnityEngine;

public class IdleState : State
{
    private float xInput;

    public IdleState(CharacterStateMachine stateMachine) : base("IdleState", stateMachine) { }

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
            stateMachine.SetState("MovementState");
        }
    }

}
