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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        defenderController.Update();
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

    public void AddStar()
    {
        AudioService.Instance.Play(SoundType.GetStar);
        CurrencyManager.Instance.AddCurrency(25);
    }

    public void SetController(DefenderController defenderController)
    {
        this.defenderController = defenderController;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
