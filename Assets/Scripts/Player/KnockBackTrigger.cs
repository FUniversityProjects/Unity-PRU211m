using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackTrigger : MonoBehaviour
{
  private float knockbackdame = 20;
  private void OnCollisionEnter2D(Collision2D other)
  {
    var player = other.collider.GetComponent<PlayerMovement>();
    var status = other.collider.GetComponent<PlayerStatus>();
    if (player != null)
    {
      status.TakeDamage(knockbackdame);
      player.KnockBack(transform);
    }
  }
}
