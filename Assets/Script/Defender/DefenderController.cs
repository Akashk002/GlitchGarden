using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderController
{
    public DefenderScriptable defenderScriptable;
    public DefenderView defenderView;
    protected DefenderModel defenderModel;
    protected Slot slot;
    private float fireTimer = 0f;


    public DefenderController(DefenderScriptable defenderScriptable, Slot slot, DefenderModel defenderModel)
    {
        defenderView = Object.Instantiate(defenderScriptable.DefenderPrefab, slot.GetPos(), Quaternion.identity);
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

    public virtual void Update()
    {

    }

    public bool AttackerFound()
    {
        Vector2 direction = Vector2.right; // use Vector3.left for negative X
        Vector2 origin = defenderView.transform.position + Vector3.up / 2;

        int layerMask = LayerMask.GetMask("Attacker");

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, defenderView.rayDistance, defenderView.detectionLayer);

        if (hit.collider != null && hit.collider.GetComponent<AttackerView>())// && hit.collider.GetComponent<AttackerView>())
        {
            Debug.Log("Detected: " + hit.collider.gameObject.name);
            return true;
        }

        return false;
    }

    public virtual void TakeDamage(int val)
    {
        defenderModel.TakeDamage(val);
    }

    public void Die()
    {
        slot.RemoveDefenderController();
        slot = null;
        GameService.Instance.DefenderService.ReturnDefenderPool(this);
        defenderView.gameObject.SetActive(false);
    }

    public void AttackAnimation(bool enable)
    {
        defenderView.AttackAnimation(enable);
    }

    public void TriggerTakeDamageAnimation()
    {
        defenderView.TriggerTakeDamageAnimation();
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
        ProjectileController projectileController = GameService.Instance.projectileService.CreateProjectile(defenderScriptable.ProjectileType, defenderView.shootPoint.position);
    }

    public virtual void ChangeStateToIdle()
    {

    }
}
