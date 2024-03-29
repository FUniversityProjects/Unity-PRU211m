using Scripts.Interfaces;
using UnityEngine;

public class BossHealth : MonoBehaviour, IDamage
{
    public float health = 500;
    public Animator anim;

    public void TakeDamage(float damage)
    {
        health -= damage;

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
        anim.SetBool("IsDeath", true);
        Destroy(gameObject);
    }
}
