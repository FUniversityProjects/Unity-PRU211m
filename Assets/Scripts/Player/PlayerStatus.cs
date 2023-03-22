using System.Collections;
using System.Collections.Generic;
using Scripts.Interfaces;
using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDamage
{
  [SerializeField] private float maxHP = 100;
  [SerializeField] private float hp;
  [SerializeField] private Animator Ani;
  public HealthBar healthBar;
  //public PlayerMovement player;

  void Start()
  {
    hp = maxHP;
    healthBar.SetHealth(hp, maxHP);
  }
  public void TakeDamage(float damage)
  {
    hp -= damage;
    healthBar.SetHealth(hp, maxHP);
    Debug.Log(hp);
    if (hp <= 0)
    {
      StartCoroutine(Die());
    }
  }
  public IEnumerator Die()
  {
    Debug.Log("Enemy died! ");
    //Die animation
    Ani.SetBool("isDead", true);
    //Disable Enemy
    yield return new WaitForSeconds(1.3f);

    Destroy(gameObject);
    // GetComponent<Collider2D>().enabled = false;
    // GetComponent<Renderer>().enabled = false;
    // this.enabled = false;

  }

  public void TakeHit()
  {
    throw new System.NotImplementedException();
  }
}
