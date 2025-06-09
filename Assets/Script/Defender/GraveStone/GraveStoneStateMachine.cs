using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveStoneStateMachine : IStateMachineDefender
{
    private DefenderController defenderController;
    private IStateDefender currentState;
    protected Dictionary<DefenderStates, IStateDefender> States = new Dictionary<DefenderStates, IStateDefender>();

    public GraveStoneStateMachine(DefenderController defenderController)
    {
        this.defenderController = defenderController;
        CreateState();
        SetOwner();
    }

    private void CreateState()
    {
        States.Add(DefenderStates.Idle, new DefenderIdleState(this));
        States.Add(DefenderStates.TakeDamage, new DefenderTakeDamageState(this));
        States.Add(DefenderStates.Die, new DefenderDieState(this));
    }

    private void SetOwner()
    {
        foreach (IStateDefender state in States.Values)
        {
            state.Owner = defenderController;
        }
    }

    public void Update() => currentState?.Update();

    public void ChangeState(IStateDefender newState)
    {
        currentState?.OnStateExit();
        currentState = newState;
        currentState?.OnStateEnter();
    }

    public void ChangeState(DefenderStates newState)
    {
        ChangeState(States[newState]);
    }
}
