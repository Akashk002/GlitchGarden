using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerPool : GenericObjectPool<AttackerController>
{
    private AttackerScriptable attackerScriptable;
    private Slot slot;
    private AttackerModel attackerModel;
    public AttackerController GetAttacker<T>(AttackerScriptable attackerScriptable, Slot slot, AttackerModel attackerModel) where T : AttackerController
    {
        this.attackerScriptable = attackerScriptable;
        this.slot = slot;
        this.attackerModel = attackerModel;
        return GetItem<T>();
    }

    protected override AttackerController CreateItem<T>()
    {
        if (typeof(T) == typeof(LizardController))
            return new LizardController(attackerScriptable, slot, attackerModel);
        else if (typeof(T) == typeof(FoxController))
            return new FoxController(attackerScriptable, slot, attackerModel);
        else
            throw new NotSupportedException($"This type '{typeof(T)}' is not supported.");
    }

}
