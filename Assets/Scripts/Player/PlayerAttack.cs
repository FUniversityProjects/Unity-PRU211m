using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
  [SerializeField] private Animator animator;
  [SerializeField] private Transform attackPonit;
  [SerializeField] private float attackRange = 0.5f;
  [SerializeField] private LayerMask enemyLayers;

  private float attackRate = 2f;
  private float nextAttackTime = 0f;
  void Update()
  {
    if (Time.time >= nextAttackTime)
    {
      if (Input.GetKeyDown(KeyCode.J))
      {
        Attack();
        nextAttackTime = Time.time + 1f / attackRate;
      }
    }
  }
  void Attack()
  {
    animator.SetTrigger("Attack");

    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPonit.position, attackRange, enemyLayers);
    foreach (Collider2D enemy in hitEnemies)
    {
      Debug.Log("hit");
    }
  }
  private void OnDrawGizmosSelected()
  {
    if (attackPonit == null)
      return;
    Gizmos.DrawWireSphere(attackPonit.position, attackRange);
  }

}
