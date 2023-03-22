using System.Collections;
using System.Collections.Generic;
using Scripts.Interfaces;
using UnityEngine;

public class EnemyStatus : MonoBehaviour, IDamage
{
  [SerializeField] private Rigidbody2D RB;
  [SerializeField] private float knockbackVel = 2;
  [SerializeField] private float maxHP = 50;
  [SerializeField] private float hp;
  void Start()
  {
    RB = GetComponentInParent<Rigidbody2D>();
    hp = maxHP;
    // healthBar.SetHealth(hp, maxHP);
  }
  public void TakeDamage(float damage)
  {
    var frog = GetComponentInParent<MoveAndPause>();
    var enemy = GetComponentInParent<NormalMove>();

    hp -= damage;
    Knockback();
    if (hp <= 0)
    {
      if (frog != null)
      {
        GetComponentInParent<MoveAndPause>().OnDestroy();
      }
      else if (enemy != null)
      {
        GetComponentInParent<NormalMove>().enabled = false;
        this.enabled = false;
        Destroy(gameObject);
      }
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
