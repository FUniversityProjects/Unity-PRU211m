using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [Range(1, 20)]
    [SerializeField] private float chaseRange, stopDistance;
    [Range(2, 4)]
    [SerializeField] private float speed;

    private Transform _player;
    private bool _isChasing;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _isChasing = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        if (distanceToPlayer <= chaseRange)
        {
            _isChasing = true;
        }

        if (_isChasing)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.position, speed * Time.deltaTime);

            if (distanceToPlayer <= stopDistance)
            {
                _isChasing = false;
            }
        }
    }
}
