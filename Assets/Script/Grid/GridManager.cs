using UnityEngine;

public class GridManager
{
    private int rows = 5;
    private int columns = 9;
    Vector2 origin = Vector2.zero;
    private Slot slot;
    private Vector3[,] gridPositions;
    private Slot[,] slotArray;
    private float spacingX = 1.2f; // Horizontal space between slots
    private float spacingY = 1.5f; // Vertical space between slots

    public GridManager(int rows, int columns, Slot slot)
    {
        this.rows = rows;
        this.columns = columns;
        this.slot = slot;

        float totalWidth = (columns - 1) * spacingX;
        float totalHeight = (rows - 1) * spacingY;
        origin = new Vector2(-totalWidth / 2f, -totalHeight / 2f);

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
                // Add padding to spacing
                Vector3 cellPos = new Vector3(x * spacingX, y * spacingY, 0f) + (Vector3)origin;
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
}