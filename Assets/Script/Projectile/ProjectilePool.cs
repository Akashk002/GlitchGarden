using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : GenericObjectPool<ProjectileController>
{
    private ProjectileScriptable projectileScriptable;
    private Vector3 spawnPosition;
    public ProjectileController GetProjectile<T>(ProjectileScriptable projectileScriptable, Vector3 spawnPosition) where T : ProjectileController
    {
        this.projectileScriptable = projectileScriptable;
        this.spawnPosition = spawnPosition;
        return GetItem<T>();
    }

    protected override ProjectileController CreateItem<T>()
    {
        if (typeof(T) == typeof(CorgetteController))
            return new CorgetteController(projectileScriptable, spawnPosition);
        else if (typeof(T) == typeof(AxeController))
            return new AxeController(projectileScriptable, spawnPosition);
        else
            throw new NotSupportedException($"This type '{typeof(T)}' is not supported.");
    }

}

