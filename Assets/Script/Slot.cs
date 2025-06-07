using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    private int rowIndex;
    private int columnIndex;
    private int maxColumn;
    public SlotType slotType;
    private DefenderController defenderController = null;
    private AttackerController attackerController = null;
    public Vector3 GetPos()
    {
        return GameService.Instance.GridManager.GetWorldPosition(columnIndex, rowIndex);
    }

    public Slot GetNextSlot()
    {
        if (columnIndex > 0)
        {
            return GameService.Instance.GridManager.GetSlot(columnIndex - 1, rowIndex);
        }

        return null;
    }
    public void SetSlotData(int columnIndex, int rowIndex, int maxColumn)
    {
        this.rowIndex = rowIndex;
        this.columnIndex = columnIndex;
        this.maxColumn = maxColumn;
        SetSlotType();
    }

    public void SetDefenderController(DefenderController defenderController)
    {
        if (IsEmpty())
            this.defenderController = defenderController;
    }
    public void RemoveDefenderController()
    {
        this.defenderController = null;
    }

    public void SetAttackerController(AttackerController attackerController)
    {
        this.attackerController = attackerController;
    }
    public void RemoveAttackerController()
    {
        this.attackerController = null;
    }

    public bool IsEmpty()
    {
        return defenderController == null;
    }

    private void SetSlotType()
    {
        if (columnIndex == 0)
        {
            slotType = SlotType.Base;
        }
        else if (columnIndex == maxColumn - 1)
        {
            slotType = SlotType.Spawn;
        }
        else
        {
            slotType = SlotType.Normal;
        }
    }

    public SlotType GetSlotType()
    {
        return slotType;
    }


}

[System.Serializable]
public enum SlotType
{
    Base,
    Normal,
    Spawn
}