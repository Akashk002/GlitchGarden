using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerJumpState : IStateAttacker
{
    public AttackerController Owner { get; set; }
    private IStateMachineAttacker stateMachine;

    public AttackerJumpState(IStateMachineAttacker stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter()
    {
        Owner.TriggerJumpAnimation();
        Owner.StartMoveToNextSlot();
    }
    public void Update()
    {
        Owner.Jumping();
    }

    public void OnStateExit()
    {

    }
}