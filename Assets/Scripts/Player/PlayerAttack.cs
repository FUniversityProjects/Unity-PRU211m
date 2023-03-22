using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack instance;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform attackPonit;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask enemyLayers;
    public float attackDame;

    private float attackRate = 2f;
    private float nextAttackTime = 0f;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyUp(KeyCode.J))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void Attack()
    {
        var monster = GetComponent<EnemyStatus>();
        var boss = GetComponent<GolemStatus>();
        //var enemyStatus = GetComponent<EnemyStatus>();
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPonit.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {

            if (enemy.GetComponent<EnemyStatus>() != null)
            {
                enemy.GetComponent<EnemyStatus>().TakeDamage(attackDame);
                //Debug.Log("hit");
            }
            else if (enemy.GetComponent<GolemStatus>() != null)
            {
                enemy.GetComponent<GolemStatus>().TakeDamage(attackDame);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPonit == null)
            return;
        Gizmos.DrawWireSphere(attackPonit.position, attackRange);
    }

}
