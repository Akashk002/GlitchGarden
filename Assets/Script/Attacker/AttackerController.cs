using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerController
{
    protected AttackerScriptable attackerScriptable;
    protected AttackerView attackerView;
    protected Slot slot;
    protected Slot nextSlot;

    private Vector3 targetPosition;
    private bool isMoving = false;

    private float attackInterval = 1f;
    private float attackTimer = 0f;

    public AttackerController(AttackerScriptable attackerScriptable, Slot slot)
    {
        attackerView = Object.Instantiate(attackerScriptable.AttackerPrefab, slot.GetPos(), Quaternion.identity);
        attackerView.SetController(this);
        this.attackerScriptable = attackerScriptable;
        this.slot = slot;
    }

    public void AttackerMoving()
    {
        if (!isMoving) return;
        attackerView.transform.position = Vector3.MoveTowards(attackerView.transform.position, targetPosition, attackerScriptable.Speed * Time.deltaTime);
        if (Vector3.Distance(attackerView.transform.position, targetPosition) < 0.01f)
        {
            slot.RemoveAttackerController();
            slot.GetNextSlot().SetAttackerController(this);
            slot = slot.GetNextSlot();
            attackerView.transform.position = targetPosition;
            isMoving = false;

            if (CheckNextSlotIsEmpty())
            {
                StartMoveToNextSlot();
            }
        }
    }

    public bool CheckNextSlotIsEmpty()
    {
        var nextSlot = slot.GetNextSlot();
        if (nextSlot == null || !nextSlot.IsEmpty())
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

    public virtual void UpdateAttacker() { }

    public void StartWalking()
    {
        attackerView.PlayWalkAnimation();
        StartMoveToNextSlot();
    }

    public void StartAttacking()
    {
        attackerView.PlayAttackAnimation();
    }

    public virtual void ChangeStateToWalk()
    {

    }

    public void Attacking()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackInterval)
        {
            attackTimer = 0f;
            AttackPlayer();
        }
    }

    public void AttackPlayer()
    {

    }

}
