using System.Collections.Generic;
using UnityEngine;

public class LevelService
{
    [SerializeField] private LevelScriptable levelScriptable;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float startDelay = 5f; // Delay before spawning starts

    private List<AttackerController> attackerControllerList = new List<AttackerController>();
    private float startTimer = 0f;
    private float spawnTimer = 0f;
    private int spawnedCount = 0;
    private bool canStartSpawning = false;

    public LevelService(LevelScriptable levelScriptable)
    {
        this.levelScriptable = levelScriptable;
        UIManager.Instance.UpdateLevelNumber(levelScriptable.levelIndex);
    }

    public void Update()
    {
        if (!canStartSpawning)
        {
            startTimer += Time.deltaTime;
            if (startTimer >= startDelay)
            {
                canStartSpawning = true;
            }
            return;
        }

        if (spawnedCount >= levelScriptable.attackerCount)
            return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= levelScriptable.spawnRateRange.GetRandom())
        {
            spawnTimer = 0f;
            SpawnRandomAttacker();
            spawnedCount++;

            UIManager.Instance.UpdateLevelSlider(spawnedCount, levelScriptable.attackerCount);
        }
    }

    private void SpawnRandomAttacker()
    {
        int index = Random.Range(0, levelScriptable.attackerList.Count);
        AttackerType attackerType = levelScriptable.attackerList[index];
        Slot slot = GetRandomSpawnSlot();

        AttackerController attackerController = GameService.Instance.EventService.OnSpawnAttacker.InvokeEvent(attackerType, slot);
        //AttackerController attackerController = GameService.Instance.attackerService.CreateAttacker(attackerType, slot);
        attackerControllerList.Add(attackerController);
    }

    private Slot GetRandomSpawnSlot()
    {
        var randomRow = Random.Range(0, GameService.Instance.rows);

        Slot slot = GameService.Instance.GridManager.GetSlot(GameService.Instance.columns - 1, randomRow);
        if (slot != null && slot.GetSlotType() == SlotType.Spawn && slot.IsEmpty())
        {
            return slot;
        }
        return null;
    }

    public List<DefenderType> GetDefenderList()
    {
        return levelScriptable.defenderList;
    }

    public void CheckLevelComplete()
    {
        if (spawnedCount >= levelScriptable.attackerCount)
        {
            foreach (var attackerController in attackerControllerList)
            {
                if (attackerController.CheckAttackerAlive())
                {
                    return;
                }
            }

            if (levelData.currentLevelIndex == GameService.Instance.GetLastLevelIndex())
            {
                levelData.currentLevelIndex = 0; // Reset to first level
                UIManager.Instance.ShowGameCompletePanel();
            }
            else
            {
                UIManager.Instance.ShowLevelCompletePanel();
            }
        }
    }
}

