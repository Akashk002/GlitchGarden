using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerTakeDamageState : IStateAttacker
{
    public AttackerController Owner { get; set; }
    private IStateMachineAttacker stateMachine;

    public AttackerTakeDamageState(IStateMachineAttacker stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter()
    {
        Owner.TriggerDamageAnimation();
    }
    public void Update()
    {
        if (!Owner.CheckSlotIsEmpty() && Owner.OnReachingSlot())
        {
            stateMachine.ChangeState(AttackerStates.Idle);
        }
        else
        {
            stateMachine.ChangeState(AttackerStates.Move);
        }
    }

    public void OnStateExit()
    {

    }
}
