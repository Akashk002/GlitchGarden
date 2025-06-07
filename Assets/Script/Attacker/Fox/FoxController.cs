using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : AttackerController
{
    private FoxStateMachine stateMachine;

    public FoxController(AttackerScriptable attackerScriptable, Slot slot) : base(attackerScriptable, slot)
    {
        attackerView.SetController(this);
        CreateStateMachine();
        stateMachine.ChangeState(AttackerStates.Appear);
    }

    private void CreateStateMachine() => stateMachine = new FoxStateMachine(this);

    public override void UpdateAttacker()
    {
        stateMachine.Update();
    }

    public override void ChangeStateToWalk()
    {
        stateMachine.ChangeState(AttackerStates.Move);
    }
}
