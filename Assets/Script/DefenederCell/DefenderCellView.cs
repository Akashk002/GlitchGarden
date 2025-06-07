using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class DefenderCellView : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Image DefenderBGImage;
    [SerializeField] private DefenderCellImageHandler cellImageHandler;
    private DefenderCellController defenderCellController;

    public void SetController(DefenderCellController defenderCellController)
    {
        this.defenderCellController = defenderCellController;
    }

    internal void ConfigureCellUI(DefenderScriptable defenderScriptable)
    {
        nameText.text = defenderScriptable.name;
        costText.text = defenderScriptable.Cost.ToString();
        DefenderBGImage.sprite = defenderScriptable.sprite;
        cellImageHandler.ConfigureCellImage(defenderScriptable, defenderCellController);
    }
}
