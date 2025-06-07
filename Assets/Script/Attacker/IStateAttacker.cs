

public interface IStateAttacker
{
    public AttackerController Owner { get; set; }
    public void OnStateEnter();
    public void Update();
    public void OnStateExit();
}
