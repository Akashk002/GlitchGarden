using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : AttackerController
{
    private FoxStateMachine stateMachine;

    public FoxController(AttackerScriptable attackerScriptable, Slot slot, AttackerModel attackerModel) : base(attackerScriptable, slot, attackerModel)
    {
        attackerView.SetController(this);
        CreateStateMachine();
        stateMachine.ChangeState(AttackerStates.Appear);
    }

    private void CreateStateMachine() => stateMachine = new FoxStateMachine(this);

    public override void Update()
    {
        stateMachine.Update();
    }

    public override void ChangeStateToIdle()
    {
        stateMachine.ChangeState(AttackerStates.Move);
    }

    public override void TakeDamage(int val)
    {
        base.TakeDamage(val);
        stateMachine.ChangeState(AttackerStates.TakeDamage);
    }
}
