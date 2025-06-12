using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerModel : MonoBehaviour
{
    private AttackerController attackerController;
    private int maxHealth;
    private int health;
    public AttackerModel(AttackerScriptable attackerScriptable)
    {
        this.maxHealth = attackerScriptable.Health;
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
