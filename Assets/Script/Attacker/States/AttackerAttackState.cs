using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerAttackState : IStateAttacker
{
    public AttackerController Owner { get; set; }
    private IStateMachineAttacker stateMachine;

    public AttackerAttackState(IStateMachineAttacker stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter()
    {
        Owner.StartAttacking();
    }
    public void Update()
    {

    }

    public void OnStateExit()
    {

    }
}
