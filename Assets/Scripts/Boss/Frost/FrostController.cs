using Scripts.Interfaces;
using UnityEngine;

public class FrostController : MonoBehaviour, IDamage
{
    [Header("Character")]
    [SerializeField] private Transform boss;
    [SerializeField] private Animator anim;

    [Header("Movement")]
    [Range(1, 10)]
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform leftPoint, rightPoint;
    private bool _moveRight;

    [Header("Attack")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackDamage = 20;
    public LayerMask playerLayers;

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.H))
        {
            TakeHit();
        }
#endif
    }

    public void TakeDamage(float damage)
    {
        anim.SetBool("IsHurt", true);

        // currentState = bossStates.moving;
    }

    public void TakeHit()
    {
        anim.SetTrigger("Attack");

        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        foreach (Collider2D player in hits)
        {
            player.GetComponent<PlayerStatus>().TakeDamage(attackDamage);
            Debug.Log("Hit player");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
