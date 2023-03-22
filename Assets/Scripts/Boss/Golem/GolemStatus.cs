using System.Collections;
using System.Collections.Generic;
using Scripts.Interfaces;
using UnityEngine;

public class GolemStatus : MonoBehaviour, IDamage
{
  [SerializeField] private SpriteRenderer SR;
  [SerializeField] private float maxHP = 50;
  [SerializeField] private float hp;
  void Start()
  {
    SR = GetComponentInParent<SpriteRenderer>();
    hp = maxHP;
  }
  public void TakeDamage(float damage)
  {
    hp -= damage;
    if (hp <= 0)
    {
      GetComponentInParent<BossGolemController>().OnDestroy();
      this.enabled = false;
    }
  }

  public void TakeHit()
  {
    throw new System.NotImplementedException();
  }


}
