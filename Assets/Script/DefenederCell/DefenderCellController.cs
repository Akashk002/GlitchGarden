using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderCellController
{
    private DefenderCellView defenderCellView;
    private DefenderScriptable defenderScriptable;

    public DefenderCellController(DefenderScriptable defenderScriptable, DefenderCellView defenderCellPrefab, Transform defenderCellTransform)
    {
        defenderCellView = Object.Instantiate(defenderCellPrefab, defenderCellTransform);
        defenderCellView.SetController(this);
        defenderCellView.ConfigureCellUI(defenderScriptable);
        this.defenderScriptable = defenderScriptable;
    }

    public DefenderType GetDefenderType()
    {
        return defenderScriptable.DefenderType;
    }
}
