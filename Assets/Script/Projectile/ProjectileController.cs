using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController
{
    private ProjectileView projectileView;
    private Vector2 direction = Vector2.right;
    private ProjectileScriptable projectileScriptable;

    public ProjectileController(ProjectileScriptable projectileScriptable, Vector3 spawnPosition)
    {
        projectileView = Object.Instantiate(projectileScriptable.projectilePrefab, spawnPosition, Quaternion.identity);
        projectileView.SetController(this);
        this.projectileScriptable = projectileScriptable;
    }

    public void Configure(Vector3 pos)
    {
        projectileView.transform.position = pos;
        projectileView.gameObject.SetActive(true);
    }

    public void Update()
    {
        projectileView.transform.Translate(direction * projectileScriptable.speed * Time.deltaTime);
        if (OutFromScreen())
        {
            SelfDestruct();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        AttackerView attacker = collision.GetComponent<AttackerView>();
        if (attacker)
        {
            AudioService.Instance.Play(SoundType.BulletStrikeAttacker);
            attacker.TakeDamage(projectileScriptable.damage);
            SelfDestruct();
        }
    }

    private void SelfDestruct()
    {
        GameService.Instance.projectileService.ReturnProjectilePool(this);
        projectileView.gameObject.SetActive(false);
    }

    private bool OutFromScreen()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(projectileView.transform.position);
        if (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
        {
            return true;
        }
        return false;
    }
}
