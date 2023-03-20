using Scripts.Interfaces;
using UnityEngine;

public class BossHealth : MonoBehaviour, IDamage
{
    public float health = 500;
    public GameObject deathEffect;
    public bool isInvulnerable = false;

    public void TakeDamage(float damage)
    {
        if (isInvulnerable) return;

        health -= damage;

        if (health <= 200)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeHit()
    {
        throw new System.NotImplementedException();
    }

    private void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
