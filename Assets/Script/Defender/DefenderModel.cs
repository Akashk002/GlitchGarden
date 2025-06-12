using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderModel
{
    private DefenderController defenderController;
    private int maxHealth;
    private int health;
    public DefenderModel(DefenderScriptable defenderScriptable)
    {
        this.maxHealth = defenderScriptable.Health;
    }

    public void SetHealth()
    {
        health = maxHealth;
    }

    public void SetDefenderController(DefenderController defenderController)
    {
        this.defenderController = defenderController;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Defender Take Damage: " + damage + " , Health before: " + health);
        health -= damage;
        if (health <= 0)
        {
            defenderController.Die();
        }
    }
}
