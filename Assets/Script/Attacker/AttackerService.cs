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

    public void CreateAttacker(AttackerType attackerType)
    {
        Slot slot = GetRandomSpawnSlot();

        AttackerScriptable attackerScriptable = attackerDataList.Find(data => data.AttackerType == attackerType)?.AttackerScriptable;
        AttackerModel attackerModel = new AttackerModel(attackerScriptable);

        AttackerController attackerController = (attackerType == AttackerType.Lizard)
            ? attackerPool.GetAttacker<LizardController>(attackerScriptable, slot, attackerModel)
            : attackerPool.GetAttacker<FoxController>(attackerScriptable, slot, attackerModel);

        attackerController.Configure(slot.GetPos());
    }

    private Slot GetRandomSpawnSlot()
    {
        var randomRow = Random.Range(0, GameService.Instance.rows - 1);

        Slot slot = GameService.Instance.GridManager.GetSlot(GameService.Instance.columns - 1, randomRow);
        if (slot != null && slot.GetSlotType() == SlotType.Spawn && slot.IsEmpty())
        {
            return slot;
        }

        return null;
    }

    public void ReturnAttackerPool(AttackerController attackerController) => attackerPool.ReturnItem(attackerController);
}
