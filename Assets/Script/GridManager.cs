using System.Collections.Generic;
using UnityEngine;

public class GridManager
{
    private int rows = 5;
    private int columns = 9;
    private float cellWidth = 1.2f;
    private float cellHeight = 1.5f;
    Vector2 origin = Vector2.zero;
    private Slot slot;
    private Vector3[,] gridPositions;
    private Slot[,] slotArray;

    public GridManager(int rows, int columns, Slot slot = null)
    {
        this.rows = rows;
        this.columns = columns;
        this.slot = slot;
        origin = new Vector2(-(columns / 2f) - 1, -(rows / 2f) - .25f);
        GenerateGrid();
    }

    void GenerateGrid()
    {
        GameObject gameObject = new GameObject("Slots");

        gridPositions = new Vector3[columns, rows];
        slotArray = new Slot[columns, rows];

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                // Bottom-left corner as origin
                Vector3 cellPos = new Vector3(x * cellWidth, y * cellHeight, 0f) + (Vector3)origin;
                gridPositions[x, y] = cellPos;

                if (slot != null)
                {
                    GameObject slotObj = Object.Instantiate(slot.gameObject, cellPos, Quaternion.identity);
                    slotObj.transform.SetParent(gameObject.transform, false);
                    Slot newSlot = slotObj.GetComponent<Slot>();
                    newSlot.SetSlotData(x, y, columns);
                    slotObj.name = $"Slot_{x}_{y}";
                    slotArray[x, y] = newSlot;
                }
            }
        }
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return gridPositions[x, y];
    }

    public Slot GetSlot(int x, int y)
    {
        if (IsCellWithinBounds(x, y))
        {
            return slotArray[x, y];
        }
        return null;
    }

    public bool IsCellWithinBounds(int x, int y)
    {
        return x >= 0 && y >= 0 && x < columns && y < rows;
    }

    public Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x);
        int y = Mathf.FloorToInt(worldPosition.y);
        return new Vector2Int(x, y);
    }

    public Slot[,] GetSlotArray()
    {
        return slotArray;
    }
}