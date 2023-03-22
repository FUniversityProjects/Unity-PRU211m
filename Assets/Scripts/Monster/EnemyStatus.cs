using System.Collections;
using System.Collections.Generic;
using Scripts.Interfaces;
using UnityEngine;

public class EnemyStatus : MonoBehaviour, IDamage
{
    private Rigidbody2D RB;
    [SerializeField] private float knockbackVel = 2;
    [SerializeField] private float maxHP = 50;
    [SerializeField] private float hp;

    [SerializeField] private HealthBar healthBar;

    [SerializeField] private GameObject parent;


    void Start()
    {
        RB = GetComponentInParent<Rigidbody2D>();
        hp = maxHP;
        healthBar.SetHealth(hp, maxHP);
        // healthBar.SetHealth(hp, maxHP);
    }
    public void TakeDamage(float damage)
    {
        // var oposums = GetComponentInParent<OpposumMove>();
        // var bunny = GetComponentInParent<NormalMove>();

        hp -= damage;
        healthBar.TakeDmgUI(hp);
        Knockback();
        if (hp <= 0)
        {
            // if (oposums != null)
            // {
            //     GetComponentInParent<OpposumMove>().enabled = false;
            //     this.enabled = false;
            //     Destroy(parent);
            // }
            // else if (bunny != null)
            // {
            //     GetComponentInParent<NormalMove>().enabled = false;
            //     this.enabled = false;
            //     Destroy(parent);
            // }
            // this.enabled = false;
            Destroy(parent);
        }
    }
    void Knockback()
    {
        RB.velocity = new Vector2(-knockbackVel * 2f, knockbackVel);
    }

    public void TakeHit()
    {
        throw new System.NotImplementedException();
    }
}
