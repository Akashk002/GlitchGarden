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
        attackerController.Update();
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

    public void TriggerJumpAnimation()
    {
        animator.SetTrigger("JumpTrigger");
    }

    public void TriggerDamageAnimation()
    {
        animator.SetTrigger("TakeDamage");
    }

    public void TakeDamage(int damageRate)
    {
        attackerController.TakeDamage(damageRate);
    }
}
