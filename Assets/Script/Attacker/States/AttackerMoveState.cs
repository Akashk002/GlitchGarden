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
        Owner.StartWalking();
    }
    public void Update()
    {
        Debug.Log("Attacker Move State Update");

        if (Owner.CheckNextSlotIsEmpty())
        {
            Owner.AttackerMoving();

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
