using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileService
{
    private List<ProjectileData> projectileDataList;
    private ProjectilePool projectilePool;

    public ProjectileService(List<ProjectileData> projectileDataList)
    {
        this.projectileDataList = projectileDataList;
        projectilePool = new ProjectilePool();
    }

    internal void SubscribeEvents()
    {
        GameService.Instance.EventService.OnShootProjectile.AddListener(CreateProjectile);
    }

    internal void UnsubscribeEvents()
    {
        GameService.Instance.EventService.OnShootProjectile.RemoveListener(CreateProjectile);
    }

    public void CreateProjectile(ProjectileType projectileType, Vector3 pos)
    {
        ProjectileScriptable projectileScriptable = projectileDataList.Find(data => data.projectileType == projectileType)?.projectileScriptable;

        ProjectileController projectileController = (projectileType == ProjectileType.Corgette)
            ? projectilePool.GetProjectile<CorgetteController>(projectileScriptable, pos)
            : projectilePool.GetProjectile<AxeController>(projectileScriptable, pos);

        projectileController.Configure(pos);
    }

    public void ReturnProjectilePool(ProjectileController projectileController) => projectilePool.ReturnItem(projectileController);
}
