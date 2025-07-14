public class AttackerAppearState : IStateAttacker
{
    public AttackerController Owner { get; set; }
    private IStateMachineAttacker stateMachine;

    public AttackerAppearState(IStateMachineAttacker stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter() { }

    public void Update() { }

    public void OnStateExit() { }
}
