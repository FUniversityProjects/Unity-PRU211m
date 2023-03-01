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

  private void Awake()
  {
    animator = GetComponent<Animator>();
    polygonCollider2D = GetComponent<PolygonCollider2D>();
  }

  private void Update()
  {
    if (hit) return;
    float movementSpeed = speed * Time.deltaTime * direction;
    transform.Translate(movementSpeed, 0, 0);
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    hit = true;
    polygonCollider2D.enabled = false;
    animator.SetTrigger("explode");
  }
  public void SetDerection(float _direction)
  {
    direction = _direction;
    gameObject.SetActive(true);
    hit = false;
    polygonCollider2D.enabled = true;

    float localScaleX = transform.localScale.x;
    if (Mathf.Sign(localScaleX) != _direction)
      localScaleX = -localScaleX;

    transform.localScale = new Vector3(localScaleX, transform.lossyScale.y, transform.lossyScale.z);
  }

  private void Deactivate()
  {
    gameObject.SetActive(false);
  }
}
