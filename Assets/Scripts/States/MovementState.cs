using UnityEngine;

public class MovementState : State
{
    private CharacterStateMachine _charStateMachine = null;
    private float xInput;

    public override void InitState()
    {
        base.InitState();

        _charStateMachine = (CharacterStateMachine)stateMachine;
    }

    public override void EnterState()
    {
        base.EnterState();
        xInput = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        xInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(xInput) < Mathf.Epsilon)
            SetState<IdleState>();
    }

    public override void LateUpdateState()
    {
        base.LateUpdateState();

        Vector3 xMovement = new Vector2(xInput * _charStateMachine.CharacterSpeed * Time.deltaTime, 0f);
        _charStateMachine.transform.position += xMovement;
    }

}
