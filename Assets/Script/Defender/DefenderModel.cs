using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderModel
{
    private DefenderController defenderController;
    private int health;
    public DefenderModel(DefenderScriptable defenderScriptable)
    {
        this.health = defenderScriptable.Health;
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

    public bool IsAlive()
    {
        return health > 0;
    }

}
