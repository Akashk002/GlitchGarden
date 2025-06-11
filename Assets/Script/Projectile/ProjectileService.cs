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

    public ProjectileController CreateProjectile(ProjectileType projectileType, Vector3 pos)
    {
        ProjectileScriptable projectileScriptable = projectileDataList.Find(data => data.projectileType == projectileType)?.projectileScriptable;

        ProjectileController projectileController = (projectileType == ProjectileType.Corgette)
            ? projectilePool.GetProjectile<CorgetteController>(projectileScriptable, pos)
            : projectilePool.GetProjectile<AxeController>(projectileScriptable, pos);

        projectileController.Configure(pos);

        return projectileController;
    }

    public void ReturnProjectilePool(ProjectileController projectileController) => projectilePool.ReturnItem(projectileController);
}
