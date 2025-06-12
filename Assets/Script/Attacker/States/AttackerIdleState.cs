using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerIdleState : IStateAttacker
{
    public AttackerController Owner { get; set; }
    private IStateMachineAttacker stateMachine;

    public AttackerIdleState(IStateMachineAttacker stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter() { }

    public void Update()
    {
        if (!Owner.CheckSlotIsEmpty() && Owner.OnReachingSlot())
        {
            if (Owner.GetAttackerType() == AttackerType.Fox && Owner.GetSlotDefenderType() == DefenderType.GraveStone)
            {
                stateMachine.ChangeState(AttackerStates.Jump);
            }
            else
            {
                stateMachine.ChangeState(AttackerStates.Attack);
            }
        }
        else
        {
            stateMachine.ChangeState(AttackerStates.Move);
        }
    }

    public void OnStateExit() { }
}
