using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderAttackState : IStateDefender
{
    public DefenderController Owner { get; set; }
    private IStateMachineDefender stateMachine;

    public DefenderAttackState(IStateMachineDefender stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter()
    {

    }
    public void Update()
    {

    }

    public void OnStateExit()
    {

    }
}