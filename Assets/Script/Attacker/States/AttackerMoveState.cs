using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerMoveState : IStateAttacker
{
    public AttackerController Owner { get; set; }
    private IStateMachineAttacker stateMachine;

    public AttackerMoveState(IStateMachineAttacker stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter()
    {
        Owner.WalkAnimation(true);
        Owner.StartMoveToNextSlot();
    }
    public void Update()
    {
        if (Owner.CheckSlotIsEmpty())
        {
            Owner.Moving();
        }
        else
        {
            stateMachine.ChangeState(AttackerStates.Attack);
        }

    }

    public void OnStateExit()
    {
        Owner.WalkAnimation(false);
    }
}
