using UnityEngine;

public class MovementState : State
{
    private CharacterStateMachine charStateMachine = null;
    private float xInput;

    public MovementState(CharacterStateMachine stateMachine) : base("MovementState", stateMachine)
    {
        charStateMachine = stateMachine;
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();

        xInput = 0;
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();

        xInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(xInput) < Mathf.Epsilon)
            stateMachine.SetState("IdleState");
    }

    public override void OnStateLateUpdate()
    {
        base.OnStateLateUpdate();

        Vector3 xMovement = new Vector2(xInput * charStateMachine.CharacterSpeed * Time.deltaTime, 0f);
        charStateMachine.transform.position += xMovement;
    }

}
