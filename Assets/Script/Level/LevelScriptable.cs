using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelScriptableObject", menuName = "ScriptableObjects/LevelScriptableObject")]
public class LevelScriptable : ScriptableObject
{
    public int levelIndex;
    public MinMaxRange spawnRateRange;
    public int attackerCount;
    public int rowCount;
    public List<AttackerType> attackerList = new List<AttackerType>();
    public List<DefenderType> defenderList = new List<DefenderType>();
}

[System.Serializable]
public struct MinMaxRange
{
    public float min;
    public float max;

    public float GetRandom()
    {
        return Random.Range(min, max);
    }
}