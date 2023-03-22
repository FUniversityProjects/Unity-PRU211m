using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashX : MonoBehaviour
{
  [SerializeField] private float speed;
  private float direction;
  private bool hit;
  private Animator animator;
  private PolygonCollider2D polygonCollider2D;
  [SerializeField] private float deactive = 0;
  [SerializeField] private float skillDame;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

  private void Update()
  {
    if (hit) return;
    float movementSpeed = (speed * Time.deltaTime * direction);
    transform.Translate(movementSpeed, 0, 0);
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    var enemy = collision.collider.GetComponent<EnemyStatus>();
    var boss = collision.collider.GetComponent<GolemStatus>();
    hit = true;
    polygonCollider2D.enabled = false;

    if (enemy != null)
    {
      enemy.TakeDamage(skillDame);
      Deactivate();
    }
    else if (boss != null)
    {
      boss.TakeDamage(skillDame);
      Deactivate();
    }
  }

    public void SetDerection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        polygonCollider2D.enabled = true;

        // float localScaleX = PlayerMovement.instance.transform.localScale.x;
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {

        if (deactive >= 2)
        {
            polygonCollider2D.enabled = false;
            Deactivate();
            deactive = 0;
        }
        else
        {
            deactive += Time.deltaTime;
        }

  }

}
