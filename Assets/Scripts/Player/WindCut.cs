using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindCut : MonoBehaviour
{
  [SerializeField] private float speed;
  private float direction;
  private bool hit;
  private Animator animator;
  private PolygonCollider2D polygonCollider2D;
  [SerializeField] private float deactive = 0;

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
  private void OnCollisionEnter2D(Collision2D collision)
  {
    hit = true;
    polygonCollider2D.enabled = false;
    Deactivate();
  }
  public void SetDerection(float _direction)
  {
    direction = _direction;
    gameObject.SetActive(true);
    hit = false;
    polygonCollider2D.enabled = true;

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
