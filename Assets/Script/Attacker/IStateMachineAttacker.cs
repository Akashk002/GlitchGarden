using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateMachineAttacker
{
    public void ChangeState(AttackerStates newState);
}

public enum AttackerStates
{
    Appear,
    Idle,
    Move,
    Attack,
    Jump,
    Die,
}

