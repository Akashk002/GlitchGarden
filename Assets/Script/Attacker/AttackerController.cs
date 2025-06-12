using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerController
{
    private AttackerView attackerView;
    private AttackerScriptable attackerScriptable;
    private AttackerModel attackerModel;
    private Slot slot;

    private Vector3 targetPosition;
    private bool isMoving = false;
    private float attackInterval = 1f;
    private float attackTimer = 0f;

    public AttackerController(AttackerScriptable attackerScriptable, Slot slot, AttackerModel attackerModel)
    {
        attackerView = Object.Instantiate(attackerScriptable.AttackerPrefab, slot.GetPos(), Quaternion.identity);
        attackerView.SetController(this);
        this.attackerScriptable = attackerScriptable;
        this.slot = slot;
        this.attackerModel = attackerModel;
        attackerModel.SetAttackerController(this);
    }

    public void Configure(Vector3 spawnPosition)
    {
        attackerView.transform.position = spawnPosition;
        attackerView.gameObject.SetActive(true);
        attackerModel.SetHealth();
    }

    public virtual void Update() { }

    public virtual void ChangeStateToIdle() { }

    public virtual void TakeDamage(int val)
    {
        attackerModel.TakeDamage(val);
    }

    public void WalkAnimation(bool enable)
    {
        attackerView.WalkAnimation(enable);
    }

    public void AttackAnimation(bool enable)
    {
        attackerView.AttackAnimation(enable);
    }

    public void TriggerTakeDamageAnimation()
    {
        attackerView.TriggerDamageAnimation();
    }

    public void TriggerJumpAnimation()
    {
        attackerView.TriggerJumpAnimation();
    }

    public void Moving()
    {
        if (!isMoving) return;
        attackerView.transform.position = Vector3.MoveTowards(attackerView.transform.position, targetPosition, (attackerScriptable.Speed * Time.deltaTime) / 10);
        if (Vector3.Distance(attackerView.transform.position, targetPosition) < 0.01f)
        {
            slot = slot.GetNextSlot();
            attackerView.transform.position = targetPosition;
            isMoving = false;

            if (CheckSlotIsEmpty())
            {
                StartMoveToNextSlot();
            }
        }
    }

    public void Jumping()
    {
        if (!isMoving) return;
        attackerView.transform.position = Vector3.MoveTowards(attackerView.transform.position, targetPosition, (attackerScriptable.JumpSpeed * Time.deltaTime) / 10);
        if (Vector3.Distance(attackerView.transform.position, targetPosition) < 0.01f)
        {
            if (slot.GetSlotType() == SlotType.Base)
            {
                UIManager.Instance.ShowGameOverPanel();
            }

            slot = slot.GetNextSlot();
            attackerView.transform.position = targetPosition;
            isMoving = false;

            if (CheckSlotIsEmpty())
            {
                StartMoveToNextSlot();
            }
        }
    }

    public bool OnReachingSlot()
    {
        return Vector3.Distance(attackerView.transform.position, targetPosition) < 0.01f;
    }

    public bool CheckSlotIsEmpty()
    {
        if (slot.GetSlotType() != SlotType.Spawn && !slot.IsEmpty())
        {
            return false;
        }
        return true;
    }

    public void StartMoveToNextSlot()
    {
        if (slot.GetSlotType() == SlotType.Base)
        {
            UIManager.Instance.ShowGameOverPanel();
            return;
        }

        var nextSlot = slot.GetNextSlot();
        targetPosition = new Vector3(nextSlot.GetPos().x, attackerView.transform.position.y, attackerView.transform.position.z);
        isMoving = true;
    }

    public void Attacking()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackInterval)
        {
            attackTimer = 0f;

            AttackDefender();
        }
    }

    public void AttackDefender()
    {
        AudioService.Instance.Play(SoundType.AttackerAttack);
        DefenderController defenderController = slot.GetDefenderController();
        defenderController.TakeDamage(attackerScriptable.Damage);
    }

    public AttackerType GetAttackerType()
    {
        return attackerScriptable.AttackerType;
    }

    public DefenderType GetSlotDefenderType()
    {
        return slot.GetDefenderController().GetDefenderType();
    }

    public bool CheckAttackerAlive()
    {
        return attackerView.gameObject.activeInHierarchy;
    }

    public void Die()
    {
        GameService.Instance.attackerService.ReturnAttackerPool(this);
        attackerView.gameObject.SetActive(false);
        GameService.Instance.LevelService.CheckLevelComplete();
    }
}
