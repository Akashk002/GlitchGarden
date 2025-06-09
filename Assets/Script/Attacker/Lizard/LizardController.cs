using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardController : AttackerController
{
    private LizardStateMachine stateMachine;

    public LizardController(AttackerScriptable attackerScriptable, Slot slot, AttackerModel attackerModel) : base(attackerScriptable, slot, attackerModel)
    {
        attackerView.SetController(this);
        CreateStateMachine();
        stateMachine.ChangeState(AttackerStates.Appear);
    }

    private void CreateStateMachine() => stateMachine = new LizardStateMachine(this);

    public override void Update()
    {
        stateMachine.Update();
    }

    public override void ChangeStateToIdle()
    {
        stateMachine.ChangeState(AttackerStates.Idle);
    }
}