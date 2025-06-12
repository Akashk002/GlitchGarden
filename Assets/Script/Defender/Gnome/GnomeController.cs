using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeController : DefenderController
{
    private GnomeStateMachine stateMachine;
    public GnomeController(DefenderScriptable defenderScriptable, Slot slot, DefenderModel defenderModel) : base(defenderScriptable, slot, defenderModel)
    {
        CreateStateMachine();
        stateMachine.ChangeState(DefenderStates.Idle);
    }
    private void CreateStateMachine() => stateMachine = new GnomeStateMachine(this);

    public override void Update()
    {
        stateMachine.Update();
    }

    public override void ChangeStateToIdle()
    {
        stateMachine.ChangeState(DefenderStates.Idle);
    }

    public override void TakeDamage(int val)
    {
        base.TakeDamage(val);
        stateMachine.ChangeState(DefenderStates.TakeDamage);
    }
}
