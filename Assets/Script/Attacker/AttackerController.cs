using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerController
{
    public AttackerScriptable attackerScriptable;
    protected AttackerView attackerView;
    protected AttackerModel attackerModel;
    protected Slot slot;

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

    public void Moving()
    {
        if (!isMoving) return;
        attackerView.transform.position = Vector3.MoveTowards(attackerView.transform.position, targetPosition, attackerScriptable.Speed * Time.deltaTime);
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
        attackerView.transform.position = Vector3.MoveTowards(attackerView.transform.position, targetPosition, attackerScriptable.Speed * Time.deltaTime * 3);
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
        var nextSlot = slot.GetNextSlot();
        targetPosition = new Vector3(nextSlot.GetPos().x, attackerView.transform.position.y, attackerView.transform.position.z);
        isMoving = true;
    }

    public virtual void Update() { }

    public void WalkAnimation(bool enable)
    {
        attackerView.WalkAnimation(enable);
    }

    public void AttackAnimation(bool enable)
    {
        attackerView.AttackAnimation(enable);
    }

    public void TriggerDamageAnimation()
    {
        attackerView.TriggerDamageAnimation();
    }

    public void TriggerJumpAnimation()
    {
        attackerView.TriggerJumpAnimation();
    }

    public virtual void ChangeStateToIdle()
    {

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
        DefenderController defenderController = slot.GetDefenderController();

        Debug.Log("Attacking Defender: " + defenderController);
        defenderController.TakeDamage(attackerScriptable.Damage);
    }

    public AttackerType GetAttackerType()
    {
        return attackerScriptable.AttackerType;
    }

    public DefenderType GetSlotDefenderType()
    {
        return slot.GetDefenderController().defenderScriptable.DefenderType;
    }

    public void Die()
    {
        attackerView.Die();
    }

    public void TakeDamage(int val)
    {
        attackerView.animator.SetTrigger("TakeDamage");
        attackerModel.TakeDamage(val);
    }
}
