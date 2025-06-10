using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyManager : GenericMonoSingleton<CurrencyManager>
{
    private int currencyAmount = 1000;
    public int CurrencyAmount
    {
        get { return currencyAmount; }
        set
        {
            currencyAmount = value;
            UpdateCurrencyText();
        }
    }
    private void Start()
    {
        UpdateCurrencyText();
    }
    private void UpdateCurrencyText()
    {
        UIManager.Instance.UpdateStarCount(currencyAmount);
    }
    public void AddCurrency(int amount)
    {
        CurrencyAmount += amount;
        UpdateCurrencyText();
    }
    public void SpendCurrency(int amount)
    {
        if (CurrencyAmount >= amount)
        {
            CurrencyAmount -= amount;
            UpdateCurrencyText();
        }
    }

    public bool CanAfford(int cost)
    {
        return CurrencyAmount >= cost;
    }
}
