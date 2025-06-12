using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderController
{
    private DefenderScriptable defenderScriptable;
    private DefenderView defenderView;
    private DefenderModel defenderModel;
    private Slot slot;
    private float fireTimer = 0f;

    public DefenderController(DefenderScriptable defenderScriptable, Slot slot, DefenderModel defenderModel)
    {
        defenderView = Object.Instantiate(defenderScriptable.DefenderPrefab);
        defenderView.SetController(this);
        this.slot = slot;
        this.defenderModel = defenderModel;
        defenderModel.SetDefenderController(this);
        this.defenderScriptable = defenderScriptable;
    }

    public void Configure(Vector3 spawnPosition)
    {
        defenderView.transform.position = spawnPosition;
        defenderView.gameObject.SetActive(true);
    }

    public void AttackAnimation(bool enable)
    {
        defenderView.AttackAnimation(enable);
    }

    public void TriggerTakeDamageAnimation()
    {
        defenderView.TriggerTakeDamageAnimation();
    }

    public virtual void Update() { }

    public virtual void ChangeStateToIdle() { }

    public virtual void TakeDamage(int val)
    {
        defenderModel.TakeDamage(val);
    }

    public bool AttackerFound()
    {
        Vector2 direction = Vector2.right; // use Vector3.left for negative X
        Vector2 origin = defenderView.transform.position + Vector3.up / 2;
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, defenderView.rayDistance, defenderView.detectionLayer);

        if (hit.collider != null && hit.collider.GetComponent<AttackerView>())// && hit.collider.GetComponent<AttackerView>())
        {
            return true;
        }
        return false;
    }

    public void FiringProjectile()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= 1)
        {
            Fire();
            fireTimer = 0f;
        }
    }

    public void Fire()
    {
        AudioService.Instance.Play(SoundType.BulletShoot);
        GameService.Instance.EventService.OnShootProjectile.InvokeEvent(defenderScriptable.ProjectileType, defenderView.shootPoint.position);
        // ProjectileController projectileController = GameService.Instance.projectileService.CreateProjectile(defenderScriptable.ProjectileType, defenderView.shootPoint.position);
    }

    public void Die()
    {
        slot.RemoveDefenderController();
        slot = null;
        GameService.Instance.DefenderService.ReturnDefenderPool(this);
        defenderView.gameObject.SetActive(false);
    }

    public DefenderType GetDefenderType()
    {
        return defenderScriptable.DefenderType;
    }
}
