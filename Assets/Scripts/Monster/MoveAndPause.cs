using UnityEngine;

public class MoveAndPause : MonoBehaviour
{
    [Range(2, 4)]
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform leftPoint, rightPoint;
    [SerializeField] private SpriteRenderer sprite;
    private bool _movingRight;
    private Animator _anim;
    private Rigidbody2D _body;
    [SerializeField] private float moveTime, waitTime;
    private float _moveCount, _waitCount;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();

        leftPoint.parent = null;
        rightPoint.parent = null;

        _movingRight = false;

        _moveCount = moveTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_moveCount > 0)
        {
            _moveCount -= Time.deltaTime;

            Moving();

            if (_moveCount <= 0)
            {
                _waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
            }

            _anim.SetBool("isMoving", true);
        }
        else if (waitTime > 0)
        {
            _waitCount -= Time.deltaTime;
            _body.velocity = new Vector2(0f, _body.velocity.y);

            if (_waitCount <= 0)
            {
                _moveCount = Random.Range(moveTime * .75f, waitTime * 1.25f); ;
            }

            _anim.SetBool("isMoving", false);
        }
    }


    private void Moving()
    {

        if (_movingRight)
        {
            _body.velocity = new Vector2(moveSpeed, _body.velocity.y);

            sprite.flipX = false;

            if (transform.position.x > rightPoint.position.x)
            {
                _movingRight = false;
            }
        }
        else
        {
            _body.velocity = new Vector2(-moveSpeed, _body.velocity.y);

            sprite.flipX = true;

            if (transform.position.x < leftPoint.position.x)
            {
                _movingRight = true;
            }
        }
    }
}
