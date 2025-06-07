using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderDieState : IStateDefender
{
    public DefenderController Owner { get; set; }
    private IStateMachineDefender stateMachine;

    public DefenderDieState(IStateMachineDefender stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter()
    {
        throw new System.NotImplementedException();
    }
    public void Update()
    {
        throw new System.NotImplementedException();
    }

    public void OnStateExit()
    {
        throw new System.NotImplementedException();
    }
}
