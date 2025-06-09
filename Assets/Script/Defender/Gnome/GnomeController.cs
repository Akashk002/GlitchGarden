using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeController : DefenderController
{
    private GnomeStateMachine stateMachine;
    public GnomeController(DefenderScriptable defenderScriptable, Slot slot, DefenderModel defenderModel) : base(defenderScriptable, slot, defenderModel)
    {
        defenderView.SetController(this);
        CreateStateMachine();
        stateMachine.ChangeState(DefenderStates.Idle);
    }
    private void CreateStateMachine() => stateMachine = new GnomeStateMachine(this);

    public override void Update()
    {
        stateMachine.Update();
    }
}
