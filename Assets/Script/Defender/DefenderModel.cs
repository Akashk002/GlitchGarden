using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderModel
{
    private DefenderController defenderController;
    private int health;
    private Slot slot;

    public DefenderModel(DefenderScriptable defenderScriptable)
    {
        this.health = defenderScriptable.Health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {

        }
    }

    public bool IsAlive()
    {
        return health > 0;
    }

}
