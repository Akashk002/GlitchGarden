using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderIdleState : IStateDefender
{
    public DefenderController Owner { get; set; }
    private IStateMachineDefender stateMachine;

    public DefenderIdleState(IStateMachineDefender stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter()
    {

    }
    public void Update()
    {
        DefenderType defenderType = Owner.defenderScriptable.DefenderType;

        if ((defenderType == DefenderType.Cactus || defenderType == DefenderType.Gnome) && Owner.AttackerFound())
        {
            stateMachine.ChangeState(DefenderStates.Attack);
        }
    }

    public void OnStateExit()
    {
    }
}
