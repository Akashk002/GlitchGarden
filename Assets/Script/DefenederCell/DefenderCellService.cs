using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderCellService
{
    [SerializeField] private List<DefenderData> defenderDataList = new List<DefenderData>();
    private DefenderCellView defenderCellPrefab;
    private Transform defenderCellTransform;

    public DefenderCellService(List<DefenderData> defenderDataList, DefenderCellView defenderCellPrefab, Transform defenderCellTransform)
    {
        this.defenderDataList = defenderDataList;
        this.defenderCellPrefab = defenderCellPrefab;
        this.defenderCellTransform = defenderCellTransform;
        CreateCell();
    }

    private void CreateCell()
    {
        for (int i = 0; i < defenderDataList.Count; i++)
        {
            DefenderScriptable defenderScriptable = defenderDataList[i].DefenderScriptable;
            DefenderCellController defenderCellController = new DefenderCellController(defenderScriptable, defenderCellPrefab, defenderCellTransform);
        }
    }


    public GameObject DefenderCellPrefab { get; }
    public Transform DefenderCellTransform { get; }
}
