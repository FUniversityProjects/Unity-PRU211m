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

  private void OnCollisionEnter2D(Collision2D other)
  {
    var player = other.collider.GetComponent<PlayerStatus>();
    if (player != null)
    {
      //Debug.Log("trung skill");
      Destroy(gameObject);
      this.enabled = false;
    }

    //Destroy(gameObject);
  }
}
