using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerIdleState : IStateAttacker
{
    public AttackerController Owner { get; set; }
    private IStateMachineAttacker stateMachine;

    public AttackerIdleState(IStateMachineAttacker stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter()
    {

    }
    public void Update()
    {
        if (Owner.CheckSlotIsEmpty())
        {
            stateMachine.ChangeState(AttackerStates.Move);
        }
        else
        {
            stateMachine.ChangeState(AttackerStates.Attack);
        }
    }

    public void OnStateExit()
    {

    }
}
