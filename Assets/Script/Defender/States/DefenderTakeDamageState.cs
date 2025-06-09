using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderTakeDamageState : IStateDefender
{
    public DefenderController Owner { get; set; }
    private IStateMachineDefender stateMachine;

    public DefenderTakeDamageState(IStateMachineDefender stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter()
    {
        Owner.TriggerTakeDamageAnimation();
    }
    public void Update()
    {

    }

    public void OnStateExit()
    {

    }
}
