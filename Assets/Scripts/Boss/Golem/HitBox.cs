using Scripts.Interfaces;
using UnityEngine;

public class HitBox : MonoBehaviour
//, ICollisionHandler
{
  [SerializeField] private BossGolemController bossCont;


  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  // public void OnCollisionEnter2D(Collision2D collision)
  // {
  //   if (collision.gameObject.CompareTag("Player")) // && playerController attack by slash
  //   {
  //     Debug.Log("enter collision called");
  //     bossCont.TakeHit();

  //     // playerController.instance.bounce()
  //     gameObject.SetActive(false);
  //   }
  // }

  // public void OnCollisionStay2D(Collision2D collision)
  // {
  //   if (collision.gameObject.CompareTag("Player")) // && playerController attack by slash
  //   {
  //     Debug.Log("stay collision called");
  //     bossCont.TakeHit();

  //     // playerController.instance.bounce()
  //     gameObject.SetActive(false);
  //   }
  // }

  // public void OnCollisionExit2D(Collision2D collision)
  // {
  //   Debug.Log("exit");
  // }
}
