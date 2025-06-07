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
