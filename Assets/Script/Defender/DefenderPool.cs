using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderPool : GenericObjectPool<DefenderController>
{
    private DefenderScriptable defenderScriptable;
    private Slot slot;
    private DefenderModel defenderModel;
    public DefenderController GetDefender<T>(DefenderScriptable defenderScriptable, Slot slot, DefenderModel defenderModel) where T : DefenderController
    {
        this.defenderScriptable = defenderScriptable;
        this.slot = slot;
        this.defenderModel = defenderModel;
        return GetItem<T>();
    }

    protected override DefenderController CreateItem<T>()
    {
        if (typeof(T) == typeof(CactusController))
            return new CactusController(defenderScriptable, slot, defenderModel);
        else if (typeof(T) == typeof(GnomeController))
            return new GnomeController(defenderScriptable, slot, defenderModel);
        else if (typeof(T) == typeof(GraveStoneController))
            return new GraveStoneController(defenderScriptable, slot, defenderModel);
        else if (typeof(T) == typeof(StarTrophyController))
            return new StarTrophyController(defenderScriptable, slot, defenderModel);
        else
            throw new NotSupportedException($"This type '{typeof(T)}' is not supported.");
    }

}