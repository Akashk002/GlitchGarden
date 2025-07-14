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
    TakeDamage,
    Die,
}

