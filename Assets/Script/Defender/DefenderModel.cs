using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderModel
{
    private DefenderController defenderController;
    private int maxHealth;
    private int health;
    public DefenderType DefenderType;
    public DefenderView Defenderprefab;
    internal ProjectileType ProjectileType;

    public DefenderModel(DefenderScriptable defenderScriptable)
    {
        this.maxHealth = defenderScriptable.Health;
        this.DefenderType = defenderScriptable.DefenderType;
        this.Defenderprefab = defenderScriptable.DefenderPrefab;
        this.ProjectileType = defenderScriptable.ProjectileType;
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
