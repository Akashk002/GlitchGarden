using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 direction = Vector2.right;
    private int damageRate;

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        if (OutFromScreen())
        {
            Destroy(gameObject);
        }
    }

    public void SetDamageRate(int val)
    {
        damageRate = val;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AttackerView attackerView = collision.GetComponent<AttackerView>();
        if (attackerView)
        {
            AudioService.Instance.Play(SoundType.BulletStrikeAttacker);
            attackerView.attackerController.TakeDamage(damageRate);
            Destroy(gameObject);
        }
    }

    private bool OutFromScreen()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
        {
            return true;
        }
        return false;
    }
}
