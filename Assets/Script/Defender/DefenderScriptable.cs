using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefenderScriptableObject", menuName = "ScriptableObjects/DefenderScriptableObject")]
public class DefenderScriptable : ScriptableObject
{
    public DefenderType DefenderType;
    public Sprite sprite;
    public DefenderView DefenderPrefab;
    public ProjectileType ProjectileType;
    public int Health;
    public float FireRate;
    public int Cost;
    public int RecoverTime;
}

[System.Serializable]
public class DefenderData
{
    public DefenderType defenderType;
    public DefenderScriptable DefenderScriptable;
}

public enum DefenderType
{
    StarTrophy,
    Cactus,
    GraveStone,
    Gnome
}