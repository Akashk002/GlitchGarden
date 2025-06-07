using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxStateMachine : IStateMachineAttacker
{
    private AttackerController attackerController;
    private IStateAttacker currentState;
    protected Dictionary<AttackerStates, IStateAttacker> States = new Dictionary<AttackerStates, IStateAttacker>();

    public FoxStateMachine(AttackerController attackerController)
    {
        this.attackerController = attackerController;
        CreateState();
        SetOwner();
    }

    private void CreateState()
    {
        States.Add(AttackerStates.Appear, new AttackerAppearState(this));
        States.Add(AttackerStates.Idle, new AttackerIdleState(this));
        States.Add(AttackerStates.Move, new AttackerMoveState(this));
        States.Add(AttackerStates.Attack, new AttackerAttackState(this));
        States.Add(AttackerStates.Jump, new AttackerJumpState(this));
        States.Add(AttackerStates.Die, new AttackerDieState(this));
    }

    private void SetOwner()
    {
        foreach (IStateAttacker state in States.Values)
        {
            state.Owner = attackerController;
        }
    }

    public void Update() => currentState?.Update();

    public void ChangeState(IStateAttacker newState)
    {
        currentState?.OnStateExit();
        currentState = newState;
        currentState?.OnStateEnter();
    }

    public void ChangeState(AttackerStates newState)
    {
        ChangeState(States[newState]);
    }
}

