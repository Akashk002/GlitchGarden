using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTrophyController : DefenderController
{
    private StarTrophyStateMachine stateMachine;
    public StarTrophyController(DefenderScriptable defenderScriptable, Slot slot, DefenderModel defenderModel) : base(defenderScriptable, slot, defenderModel)
    {
        defenderView.SetController(this);
        CreateStateMachine();
        stateMachine.ChangeState(DefenderStates.Idle);
    }
    private void CreateStateMachine() => stateMachine = new StarTrophyStateMachine(this);

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