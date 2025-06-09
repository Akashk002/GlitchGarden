using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    [SerializeField] private Slot Slot;
    [SerializeField] private DefenderCellView DefenderCellPrefab;
    [SerializeField] private Transform DefenderCellTransform;

    [SerializeField] private List<DefenderData> DefenderDataList = new List<DefenderData>();
    [SerializeField] private List<AttackerData> AttackerDataList = new List<AttackerData>();

    public int rows = 7;
    public int columns = 15;
    public GridManager GridManager { get; private set; }
    public DefenderService DefenderService { get; private set; }
    public DefenderCellService DefenderCellService { get; private set; }
    public AttackerService attackerService { get; private set; }

    private void Start()
    {
        GridManager = new GridManager(rows, columns, Slot);
        DefenderCellService = new DefenderCellService(DefenderDataList, DefenderCellPrefab, DefenderCellTransform);
        DefenderService = new DefenderService(DefenderDataList);
        attackerService = new AttackerService(AttackerDataList);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            attackerService.CreateAttacker(AttackerType.Fox);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            attackerService.CreateAttacker(AttackerType.Lizard);
        }
    }
}