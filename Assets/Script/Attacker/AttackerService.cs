using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerService
{
    private List<AttackerData> attackerDataList;
    private AttackerPool attackerPool;
    public AttackerService(List<AttackerData> attackerDataList)
    {
        this.attackerDataList = attackerDataList;
        this.attackerPool = new AttackerPool();
    }

    public void SubscribeEvents()
    {
        GameService.Instance.EventService.OnSpawnAttacker.AddListener(CreateAttacker);
    }

    internal void UnsubscribeEvents()
    {
        GameService.Instance.EventService.OnSpawnAttacker.RemoveListener(CreateAttacker);
    }

    public AttackerController CreateAttacker(AttackerType attackerType, Slot slot)
    {
        AttackerScriptable attackerScriptable = attackerDataList.Find(data => data.AttackerType == attackerType)?.AttackerScriptable;
        AttackerModel attackerModel = new AttackerModel(attackerScriptable);

        AttackerController attackerController = (attackerType == AttackerType.Lizard)
            ? attackerPool.GetAttacker<LizardController>(attackerScriptable, slot, attackerModel)
            : attackerPool.GetAttacker<FoxController>(attackerScriptable, slot, attackerModel);

        attackerController.Configure(slot.GetPos());

        return attackerController;
    }

    public void ReturnAttackerPool(AttackerController attackerController) => attackerPool.ReturnItem(attackerController);
}
