using Scripts.Interfaces;
using UnityEngine;

public class FrostController : MonoBehaviour, IDamage
{
    [Header("Character")]
    [SerializeField] private Transform boss;
    [SerializeField] private Animator anim;


    [Header("Attack")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackDamage = 40;
    public LayerMask playerLayers;

    [Header("Detect & Moving")]
    public Transform player;
    public bool isFlipped = false;

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
    }

    public void TakeHit()
    {
        anim.SetTrigger("Hit");

        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        foreach (Collider2D player in hits)
        {
            // call dame player => player.GetComponent<PlayerHurt>().TakeDamage(dame);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void DetectPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
