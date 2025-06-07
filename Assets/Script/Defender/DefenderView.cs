using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderView : MonoBehaviour
{
    public Animator animator;
    private DefenderController defenderController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //defenderController.UpdateDefender();
    }

    public void CheckHealth()
    {
        Debug.Log("Check Health");
    }



    public void AddStar()
    {
        CurrencyHandler.Instance.AddCurrency(25);
    }

    public void SetController(DefenderController defenderController)
    {
        this.defenderController = defenderController;
    }

    public void DefenderDie()
    {
        Destroy(gameObject);
    }
}
