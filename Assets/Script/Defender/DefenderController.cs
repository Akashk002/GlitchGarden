using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderController
{
    protected DefenderScriptable defenderScriptable;
    protected DefenderView defenderView;
    protected DefenderModel defenderModel;
    protected Slot slot;

    public DefenderController(DefenderScriptable defenderScriptable, Slot slot, DefenderModel defenderModel)
    {
        defenderView = Object.Instantiate(defenderScriptable.DefenderPrefab, slot.GetPos(), Quaternion.identity);
        this.slot = slot;
        this.defenderModel = defenderModel;
        defenderModel.SetDefenderController(this);
    }

    public virtual void UpdateDefender()
    {

    }

    public void TakeDamage(int val)
    {
        defenderView.animator.SetTrigger("TakeDamage");
        defenderModel.TakeDamage(val);
    }

    public void DefenderDie()
    {
        defenderView.DefenderDie();
        slot.RemoveDefenderController();
    }
}