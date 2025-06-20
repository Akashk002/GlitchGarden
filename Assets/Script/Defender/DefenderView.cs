using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderView : MonoBehaviour
{
    public Animator animator;
    public LayerMask detectionLayer;
    public float rayDistance = 15f;
    public Transform shootPoint;
    private DefenderController defenderController;

    // Update is called once per frame
    void Update()
    {
        defenderController.Update();
    }

    public void SetController(DefenderController defenderController)
    {
        this.defenderController = defenderController;
    }

    public void ChangeStateToIdle()
    {
        defenderController.ChangeStateToIdle();
    }

    public void AttackAnimation(bool enable)
    {
        animator.SetBool("isAttacking", enable);
    }
    public void TriggerTakeDamageAnimation()
    {
        animator.SetTrigger("TakeDamage");
    }

    public void AddStarPoint()
    {
        AudioService.Instance.Play(SoundType.GetStar);
        CurrencyManager.Instance.AddCurrency(GameService.Instance.GetStarPoint());
    }
}
