using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileView : MonoBehaviour
{
    private ProjectileController projectileController;
    public void SetController(ProjectileController projectileController)
    {
        this.projectileController = projectileController;
    }

    // Update is called once per frame
    void Update()
    {
        projectileController.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        projectileController.OnTriggerEnter2D(collision);
    }
}
