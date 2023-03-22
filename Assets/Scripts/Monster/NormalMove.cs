using UnityEngine;

public class NormalMove : MonoBehaviour
{
    [Range(2, 4)]
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform leftPoint, rightPoint;
    [SerializeField] private SpriteRenderer sprite;
    private bool _movingRight;
    private Rigidbody2D _body;


    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        leftPoint.parent = null;
        rightPoint.parent = null;

        _movingRight = false;
    }

    // Update is called once per frame
    void FixedUpdate()
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
