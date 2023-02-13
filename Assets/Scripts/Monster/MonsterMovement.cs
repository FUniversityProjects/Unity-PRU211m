using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
  [Range(4, 9)]
  [SerializeField] private float moveSpeed;
  [SerializeField] private Transform leftPoint, rightPoint;
  [SerializeField] private SpriteRenderer spriteBody;
  [SerializeField] private SpriteRenderer spriteHeader;
  private bool _movingRight;
  private Animator _anim;
  private Rigidbody2D _body;

  // Start is called before the first frame update
  void Start()
  {
    _anim = GetComponent<Animator>();
    _body = GetComponent<Rigidbody2D>();

    leftPoint.parent = null;
    rightPoint.parent = null;

    _movingRight = false;
  }

  // Update is called once per frame
  void Update()
  {
    if (_movingRight)
    {
      _body.velocity = new Vector2(moveSpeed, _body.velocity.y);

      spriteBody.flipX = true;
      spriteHeader.flipX = true;

      if (transform.position.x > rightPoint.position.x)
      {
        _movingRight = false;
      }
    }
    else
    {
      _body.velocity = new Vector2(-moveSpeed, _body.velocity.y);

      spriteBody.flipX = false;
      spriteHeader.flipX = false;

      if (transform.position.x < leftPoint.position.x)
      {
        _movingRight = true;
      }
    }
  }
}
