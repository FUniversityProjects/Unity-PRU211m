using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private Rigidbody2D RB;
  private Animator Ani;
  private TrailRenderer TR;
  [SerializeField] private Transform groundCheck;
  [SerializeField] private float groundCheckRadius = 0.5f;
  [SerializeField] private float speed = 5f;
  [SerializeField] private float jumpForce = 10f;
  [SerializeField] private LayerMask collisionMask;
  [SerializeField] private int maxJump = 2;

  [SerializeField] private float dashingVeclocity = 10f;
  [SerializeField] private float dashingTime = 0.5f;
  private Vector2 dashingDir;
  private bool isDashing;
  private bool canDash = true;
  private int jumpLeft;

  // Start is called before the first frame update
  void Start()
  {
    RB = GetComponent<Rigidbody2D>();
    Ani = GetComponent<Animator>();
    jumpLeft = maxJump;
    TR = GetComponent<TrailRenderer>();
  }

  // Update is called once per frame
  void Update()
  {
    var inputX = Input.GetAxisRaw("Horizontal");
    var jumpInput = Input.GetButtonDown("Jump");
    var dashInput = Input.GetButtonDown("Dash");

    if (dashInput && canDash)
    {
      isDashing = true;
      canDash = false;
      TR.emitting = true;
      dashingDir = new Vector2(inputX, 0);
      if (dashingDir == Vector2.zero)
      {
        dashingDir = new Vector2(transform.localScale.x, 0);
      }
      StartCoroutine(StopDashing());
    }
    Ani.SetBool("IsDash", isDashing);
    if (isDashing)
    {
      RB.velocity = dashingDir.normalized * dashingVeclocity;
      return;
    }
    if (IsGrounded())
    {
      canDash = true;

    }
    RB.velocity = new Vector2(inputX * speed, RB.velocity.y);

    if (IsGrounded() && RB.velocity.y < 0)
    {
      jumpLeft = maxJump;
    }
    if (jumpInput && jumpLeft > 0)
    {
      RB.velocity = new Vector2(RB.velocity.x, jumpForce);
      jumpLeft -= 1;
    }
    if (inputX != 0)
    {
      transform.localScale = new Vector3(Mathf.Sign(inputX), 1, 1);
    }

    Ani.SetBool("IsJump", !IsGrounded());
    // Ani.SetBool("IsFall", !IsGrounded());
    Ani.SetBool("IsMove", inputX != 0);
  }
  private bool IsGrounded()
  {
    return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionMask);
  }
  private IEnumerator StopDashing()
  {
    yield return new WaitForSeconds(dashingTime);
    TR.emitting = false;
    isDashing = false;
  }

}
