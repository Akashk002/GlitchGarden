using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private int rowIndex;
    private int columnIndex;
    private int maxColumn;
    private SlotType slotType;
    private DefenderController defenderController = null;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] List<Sprite> stoneSprite = new List<Sprite>();

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
        SetSprite();
        HideStones();
    }

    private void HideStones()
    {
        if (slotType == SlotType.Base || slotType == SlotType.Spawn)
        {
            spriteRenderer.enabled = false;
        }
    }

    private void SetSprite()
    {
        int randomIndex = Random.Range(0, stoneSprite.Count);
        spriteRenderer.sprite = stoneSprite[randomIndex];
    }

    public DefenderController GetDefenderController()
    {
        return defenderController;
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