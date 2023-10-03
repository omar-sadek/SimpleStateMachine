using UnityEngine;

public class IdleState : State
{
    private float xInput;

    public override void EnterState()
    {
        base.EnterState();

        xInput = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        xInput = Mathf.Abs(Input.GetAxis("Horizontal"));
        if (xInput > Mathf.Epsilon)
            SetState<MovementState>();
    }

}
