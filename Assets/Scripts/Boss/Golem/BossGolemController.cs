using Scripts.Interfaces;
using UnityEngine;

public class BossGolemController : MonoBehaviour, IDamage
{
    public enum bossStates { attack, hurt, moving, power_skill };
    [SerializeField] private bossStates currentState;

    [Header("Character")]
    [SerializeField] private Transform boss;
    [SerializeField] private Animator anim;

    [Header("Movement")]
    [Range(1, 10)]
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform leftPoint, rightPoint;
    private bool _moveRight;

    [Header("Attack")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [Range(1, 5)]
    [SerializeField] private float timeBetweenShots;
    private float _shotCounter;

    [Header("Hurt")]
    [Range(1, 5)]
    [SerializeField] private float hurtTime;
    [SerializeField] private GameObject hitBox;
    private float _hurtCounter;
    // Start is called before the first frame update
    void Start()
    {
        currentState = bossStates.attack;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case bossStates.attack:
                _shotCounter -= Time.deltaTime;

                if (_shotCounter <= 0)
                {
                    _shotCounter = timeBetweenShots;
                    var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                    newBullet.transform.localScale = boss.transform.localScale;
                }
                break;
            case bossStates.hurt:
                if (_hurtCounter > 0)
                {
                    _hurtCounter -= Time.deltaTime;

                    if (_hurtCounter <= 0)
                    {
                        currentState = bossStates.moving;
                    }
                }
                break;
            case bossStates.moving:

                if (_moveRight)
                {
                    boss.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if (boss.position.x > rightPoint.position.x)
                    {
                        boss.localScale = new Vector3(-1, 1, 1);

                        _moveRight = false;

                        EndMovement();
                    }
                }
                else
                {
                    boss.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if (boss.position.x < leftPoint.position.x)
                    {
                        boss.localScale = Vector3.one;

                        _moveRight = true;

                        EndMovement();
                    }
                }
                break;
            case bossStates.power_skill:
                break;
        }

#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A))
        {
            TakeHit();
        }
#endif
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("TakeDamage");
    }

    public void TakeHit()
    {
        currentState = bossStates.hurt;
        _hurtCounter = hurtTime;

        anim.SetTrigger("Hit");
    }

    private void EndMovement()
    {
        currentState = bossStates.attack;

        _shotCounter = timeBetweenShots;

        anim.SetTrigger("StopMoving");

        hitBox.SetActive(true);
    }
}
