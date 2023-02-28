using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
  [SerializeField] private Animator Ani;

  [SerializeField] private int combo;
  [SerializeField] private bool attack;


  // Start is called before the first frame update
  void Start()
  {
    Ani = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    Combos();
  }

  private void Combos()
  {
    if (Input.GetKeyDown(KeyCode.J) && !attack)
    {
      attack = true;
      Ani.SetTrigger("" + combo);

    }
  }
  [SerializeField]
  private void Start_Combo()
  {
    attack = false;
    if (combo < 3)
    {
      combo++;
    }
  }
  [SerializeField]
  private void Finish_Ani()
  {
    attack = false;
    combo = 0;
  }
}
