using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackerView : MonoBehaviour
{
    private AttackerController attackerController;
    public Animator animator;
    public void SetController(AttackerController attackerController)
    {
        this.attackerController = attackerController;
    }

    private void Update()
    {
        if (attackerController != null)
        {
            attackerController.Update();
        }
    }

    public void ChangeStateToIdle()
    {
        attackerController.ChangeStateToIdle();
    }

    public void WalkAnimation(bool enable)
    {
        animator.SetBool("IsWalking", enable);
    }
    public void AttackAnimation(bool enable)
    {
        animator.SetBool("isAttacking", enable);
    }

    public void TriggerDamageAnimation()
    {
        animator.SetTrigger("TakeDamage");
    }
}
