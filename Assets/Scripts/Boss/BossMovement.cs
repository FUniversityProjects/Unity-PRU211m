using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
  [Range(4, 9)]
  [SerializeField] private float speed;
  private Rigidbody2D _body;
  private Animator _anim;
  private float _horizontalInput;

  private void Awake()
  {
    _body = GetComponent<Rigidbody2D>();
    _anim = GetComponent<Animator>();
  }

  private void Update()
  {
    _horizontalInput = Input.GetAxis("Horizontal");

    //Flip character when moving left-right
    if (_horizontalInput > 0.01f)
      transform.localScale = new Vector3(2, 2, 2);
    else if (_horizontalInput < -0.01f)
      transform.localScale = new Vector3(-2, 2, 2);

    //Set animator parameters
    _anim.SetBool("run", _horizontalInput != 0);

    _body.velocity = new Vector2(_horizontalInput * speed, _body.velocity.y);
  }
}
