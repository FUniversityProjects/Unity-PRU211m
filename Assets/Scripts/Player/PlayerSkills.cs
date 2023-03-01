using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
  [SerializeField] private float attackCooldown;
  [SerializeField] private Transform windCutPoint;
  [SerializeField] private GameObject[] windCuts;
  private Animator animator;

  private PlayerMovement playerMovement;
  private float cooldownTimer = Mathf.Infinity;

  // Start is called before the first frame update
  void Awake()
  {
    playerMovement = GetComponent<PlayerMovement>();
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.K) && cooldownTimer > attackCooldown)

      Skills();
    cooldownTimer += Time.deltaTime;

  }
  private void Skills()
  {
    animator.SetTrigger("Skill1");
    cooldownTimer = 0;
    wait();
    windCuts[0].transform.position = windCutPoint.position;
    windCuts[0].GetComponent<WindCut>().SetDerection(Mathf.Sign(transform.localScale.x));
  }
  private IEnumerator wait()
  {
    yield return new WaitForSeconds(2);
  }

}
