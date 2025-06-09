using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DefenderService
{
    private List<DefenderData> DefenderDataList = new List<DefenderData>();
    public DefenderService(List<DefenderData> DefenderDataList)
    {
        this.DefenderDataList = DefenderDataList;
    }

    public bool CreateDefender(DefenderType defenderType, Vector3 dropPostion)
    {
        Slot slot = GetSlot(dropPostion);

        if (slot != null && slot.IsEmpty() && slot.GetSlotType() == SlotType.Normal)
        {
            DefenderScriptable defenderScriptable = DefenderDataList.Find(data => data.defenderType == defenderType)?.DefenderScriptable;

            DefenderModel defenderModel = new DefenderModel(defenderScriptable);

            DefenderController defenderController = null;

            switch (defenderType)
            {
                case DefenderType.StarTrophy:
                    defenderController = new StarTrophyController(defenderScriptable, slot, defenderModel);
                    break;
                case DefenderType.Cactus:
                    defenderController = new CactusController(defenderScriptable, slot, defenderModel);
                    break;
                case DefenderType.GraveStone:
                    defenderController = new GraveStoneController(defenderScriptable, slot, defenderModel);
                    break;
                case DefenderType.Gnome:
                    defenderController = new GnomeController(defenderScriptable, slot, defenderModel);
                    break;
                default:
                    break;
            }

            slot.SetDefenderController(defenderController);
            CurrencyManager.Instance.SpendCurrency(defenderScriptable.Cost);
            return true;
        }
        return false;
    }

    private Slot GetSlot(Vector3 position)
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(position);
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

        if (hit.collider != null && hit.collider.GetComponent<Slot>())
        {
            Slot slot = hit.collider.GetComponent<Slot>();
            return hit.collider.GetComponent<Slot>();
        }

        return null;
    }
}
