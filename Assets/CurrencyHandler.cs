using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyHandler : GenericMonoSingleton<CurrencyHandler>
{
    [SerializeField] private TextMeshProUGUI currencyText;

    private int currencyAmount = 100;
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
        currencyText.text = currencyAmount.ToString();
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
