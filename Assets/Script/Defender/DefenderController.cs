using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderController
{
    protected DefenderScriptable defenderScriptable;
    protected DefenderView defenderView;
    protected DefenderModel defenderModel;
    protected Slot slot;

    public DefenderController(DefenderScriptable defenderScriptable, Slot slot)
    {
        this.defenderScriptable = defenderScriptable;
        defenderView = Object.Instantiate(defenderScriptable.DefenderPrefab, slot.GetPos(), Quaternion.identity);
        this.slot = slot;
    }

    public virtual void UpdateDefender()
    {

    }

    public void DefenderDie()
    {
        slot.RemoveDefenderController();
    }
}
