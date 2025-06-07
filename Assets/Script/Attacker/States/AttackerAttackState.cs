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
        Owner.AttackAnimation(true);
    }
    public void Update()
    {
        if (!Owner.CheckSlotIsEmpty())
        {
            Owner.Attacking();
        }
        else
        {
            stateMachine.ChangeState(AttackerStates.Idle);
        }
    }

    public void OnStateExit()
    {
        Owner.AttackAnimation(false);
    }
}
