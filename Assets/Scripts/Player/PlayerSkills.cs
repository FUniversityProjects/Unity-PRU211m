using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
  [SerializeField] private float attackCooldown;
  [SerializeField] private Transform windCutPoint;
  [SerializeField] private GameObject windCuts;
  [SerializeField] private GameObject slashX;
  private Animator animator;

  private PlayerMovement playerMovement;
  [SerializeField] private float cooldownTimer = Mathf.Infinity;
  //= Mathf.Infinity
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
    {
      Skill1();

    }
    else if (Input.GetKeyDown(KeyCode.L) && cooldownTimer > attackCooldown)
    {
      Skill2();
    }
    cooldownTimer += Time.deltaTime;
    if (cooldownTimer >= 3)
    {
      cooldownTimer = 3;
    }
  }
  private void Skill1()
  {
    animator.SetTrigger("Skill1");
    cooldownTimer = 0;
  }
  private void Skill2()
  {
    animator.SetTrigger("Skill2");
    cooldownTimer = 0;
  }
  public void FinishSkill1()
  {
    windCuts.transform.position = windCutPoint.position;
    windCuts.GetComponent<WindCut>().SetDerection(Mathf.Sign(transform.localScale.x));
  }
  public void FinishSkill2()
  {
    slashX.transform.position = windCutPoint.position;
    slashX.GetComponent<SlashX>().SetDerection(Mathf.Sign(transform.localScale.x));
  }

}
