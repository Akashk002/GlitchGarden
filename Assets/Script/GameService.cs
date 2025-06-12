using System;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    [SerializeField] private int starPoint = 25;
    [SerializeField] private Slot Slot;
    [SerializeField] private DefenderCellView DefenderCellPrefab;
    [SerializeField] private Transform DefenderCellTransform;

    [SerializeField] private List<DefenderData> DefenderDataList = new List<DefenderData>();
    [SerializeField] private List<AttackerData> AttackerDataList = new List<AttackerData>();
    [SerializeField] private List<ProjectileData> projectileDataList = new List<ProjectileData>();
    [SerializeField] private List<LevelScriptable> levelScriptableList = new List<LevelScriptable>();

    public int rows = 7;
    public int columns = 15;
    public GridManager GridManager { get; private set; }
    public DefenderService DefenderService { get; private set; }
    public DefenderCellService DefenderCellService { get; private set; }
    public AttackerService attackerService { get; private set; }
    public ProjectileService projectileService { get; private set; }
    public LevelService LevelService { get; private set; }
    public EventService EventService { get; private set; }

    private void Start()
    {
        LevelScriptable levelScriptable = levelScriptableList[levelData.currentLevelIndex];
        rows = levelScriptable.rowCount;

        LevelService = new LevelService(levelScriptable);
        GridManager = new GridManager(rows, columns, Slot);
        DefenderCellService = new DefenderCellService(DefenderDataList, DefenderCellPrefab, DefenderCellTransform);
        DefenderService = new DefenderService(DefenderDataList);
        attackerService = new AttackerService(AttackerDataList);
        projectileService = new ProjectileService(projectileDataList);
        EventService = new EventService();
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        DefenderService.SubscribeEvents();
        projectileService.SubscribeEvents();
        attackerService.SubscribeEvents();
    }

    private void OnDisable()
    {
        DefenderService.UnsubscribeEvents();
        projectileService.UnsubscribeEvents();
        attackerService.UnsubscribeEvents();
    }

    private void Update()
    {
        LevelService.Update();
    }

    public int GetLastLevelIndex()
    {
        return levelScriptableList.Count - 1;
    }

    public int GetStarPoint()
    {
        return starPoint;
    }
}

public static class levelData
{
    public static int currentLevelIndex = 0;
}