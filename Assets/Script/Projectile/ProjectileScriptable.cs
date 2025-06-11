using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileScriptableObject", menuName = "ScriptableObjects/ProjectileScriptableObject")]
public class ProjectileScriptable : ScriptableObject
{
    public ProjectileType projectileType;
    public ProjectileView projectilePrefab;
    public int speed;
    public int damage;
}

[System.Serializable]
public class ProjectileData
{
    public ProjectileType projectileType;
    public ProjectileScriptable projectileScriptable;
}

public enum ProjectileType
{
    Corgette,
    Axe
}