using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveStoneController : DefenderController
{
    private GraveStoneStateMachine stateMachine;
    public GraveStoneController(DefenderScriptable defenderScriptable, Slot slot) : base(defenderScriptable, slot)
    {
        defenderView.SetController(this);
        CreateStateMachine();
        stateMachine.ChangeState(DefenderStates.Idle);
    }
    private void CreateStateMachine() => stateMachine = new GraveStoneStateMachine(this);

    public override void UpdateDefender()
    {
        stateMachine.Update();
    }
}