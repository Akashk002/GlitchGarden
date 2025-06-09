using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerService
{
    private List<AttackerData> attackerDataList;

    public AttackerService(List<AttackerData> attackerDataList)
    {
        this.attackerDataList = attackerDataList;
    }

    public bool CreateAttacker(AttackerType attackerType)
    {
        Slot slot = GetRandomSpawnSlot();

        if (slot != null && slot.IsEmpty() && slot.GetSlotType() == SlotType.Spawn)
        {
            AttackerScriptable attackerScriptable = attackerDataList.Find(data => data.AttackerType == attackerType)?.AttackerScriptable;

            AttackerModel attackerModel = new AttackerModel(attackerScriptable);

            AttackerController attackerController = (attackerType == AttackerType.Lizard) ? new LizardController(attackerScriptable, slot, attackerModel) : new FoxController(attackerScriptable, slot, attackerModel);
            return true;
        }
        return false;
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
}
