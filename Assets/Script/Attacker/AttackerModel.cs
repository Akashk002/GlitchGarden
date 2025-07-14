using UnityEngine;

public class AttackerModel : MonoBehaviour
{
    private AttackerController attackerController;
    private int maxHealth;
    private int health;
    public AttackerType AttackerType;
    public int Damage;
    public float JumpSpeed;
    public float Speed;

    public AttackerModel(AttackerScriptable attackerScriptable)
    {
        this.maxHealth = attackerScriptable.Health;
        this.AttackerType = attackerScriptable.AttackerType;
        this.Damage = attackerScriptable.Damage;
        this.JumpSpeed = attackerScriptable.JumpSpeed;
        this.Speed = attackerScriptable.Speed;
    }

    public void SetHealth()
    {
        health = maxHealth;
    }

    public void SetAttackerController(AttackerController attackerController)
    {
        this.attackerController = attackerController;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Attacker Take Damage: " + damage + " , Health before: " + health);
        health -= damage;
        if (health <= 0)
        {
            attackerController.Die();
        }
    }
}
