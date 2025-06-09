using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderAttackState : IStateDefender
{
    public DefenderController Owner { get; set; }
    private IStateMachineDefender stateMachine;

    public DefenderAttackState(IStateMachineDefender stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter()
    {
        Owner.AttackAnimation(true);
    }
    public void Update()
    {
        if (Owner.AttackerFound())
        {
            Owner.FiringProjectile();
        }
        else
        {
            stateMachine.ChangeState(DefenderStates.Idle);
        }
    }

    public void OnStateExit()
    {
        Owner.AttackAnimation(false);
    }
}