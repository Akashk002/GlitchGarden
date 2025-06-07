using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerDieState : IStateAttacker
{
    public AttackerController Owner { get; set; }
    private IStateMachineAttacker stateMachine;

    public AttackerDieState(IStateMachineAttacker stateMachine) => this.stateMachine = stateMachine;

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