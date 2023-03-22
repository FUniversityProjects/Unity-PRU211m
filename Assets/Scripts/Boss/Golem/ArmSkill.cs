using UnityEngine;

public class ArmSkill : MonoBehaviour
{
    [Range(3, 10)]
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * transform.localScale.x * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // make damage to player
        }

        Destroy(gameObject);
    }
}
