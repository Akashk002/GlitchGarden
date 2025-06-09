using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusController : DefenderController
{
    private CactusStateMachine stateMachine;
    public CactusController(DefenderScriptable defenderScriptable, Slot slot, DefenderModel defenderModel) : base(defenderScriptable, slot, defenderModel)
    {
        defenderView.SetController(this);
        CreateStateMachine();
        stateMachine.ChangeState(DefenderStates.Idle);
    }
    private void CreateStateMachine() => stateMachine = new CactusStateMachine(this);

    public override void Update()
    {
        stateMachine.Update();
    }
}

