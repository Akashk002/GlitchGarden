using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateDefender
{
    public DefenderController Owner { get; set; }
    public void OnStateEnter();
    public void Update();
    public void OnStateExit();
}