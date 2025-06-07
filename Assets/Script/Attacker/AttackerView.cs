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
            attackerController.UpdateAttacker();
        }
    }

    public void ChangeStateToWalk()
    {
        attackerController.ChangeStateToWalk();
    }

    public void PlayWalkAnimation()
    {
        animator.SetBool("IsWalking", true);
    }
    public void PlayAttackAnimation()
    {
        animator.SetBool("IsWalking", false);
        animator.SetBool("isAttacking", true);
    }
}
