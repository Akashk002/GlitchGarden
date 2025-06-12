using UnityEngine;

public class DefenderCellController
{
    private DefenderCellView defenderCellView;

    public DefenderCellController(DefenderScriptable defenderScriptable, DefenderCellView defenderCellPrefab, Transform defenderCellTransform)
    {
        defenderCellView = Object.Instantiate(defenderCellPrefab, defenderCellTransform);
        defenderCellView.SetController(this);
        defenderCellView.ConfigureCellUI(defenderScriptable);
    }
}
