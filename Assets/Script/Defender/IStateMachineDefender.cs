using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateMachineDefender
{
    public void ChangeState(DefenderStates newState);
}

public enum DefenderStates
{
    Idle,
    Attack,
    TakeDamage,
    Die,
}