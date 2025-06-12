using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackerScriptableObject", menuName = "ScriptableObjects/AttackerScriptableObject")]
public class AttackerScriptable : ScriptableObject
{
    public AttackerType AttackerType;
    public Sprite sprite;
    public AttackerView AttackerPrefab;
    public int Health;
    public int Damage;
    public float Speed;
    public float JumpSpeed;
}

[System.Serializable]
public class AttackerData
{
    public AttackerType AttackerType;
    public AttackerScriptable AttackerScriptable;
}

[System.Serializable]
public enum AttackerType
{
    Lizard,
    Fox
}
