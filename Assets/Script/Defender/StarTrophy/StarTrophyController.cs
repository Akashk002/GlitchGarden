using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTrophyController : DefenderController
{
    private StarTrophyStateMachine stateMachine;
    public StarTrophyController(DefenderScriptable defenderScriptable, Slot slot) : base(defenderScriptable, slot)
    {
        defenderView.SetController(this);
        CreateStateMachine();
        stateMachine.ChangeState(DefenderStates.Idle);
    }
    private void CreateStateMachine() => stateMachine = new StarTrophyStateMachine(this);

    public override void UpdateDefender()
    {
        stateMachine.Update();
    }
}