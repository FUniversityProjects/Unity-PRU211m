using System.Collections;
using Scripts.Interfaces;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDamage
{
    [SerializeField] private float maxHP = 100;
    [SerializeField] private float hp;
    [SerializeField] private Animator Ani;
    [SerializeField] private GameObject parent;
    public HealthBar healthBar;
    public bool isDead = false;
    private Vector3 respawnPoint;


    void Start()
    {
        hp = maxHP;
        healthBar.SetHealth(hp, maxHP);
        respawnPoint = transform.position;
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
        healthBar.TakeDmgUI(hp);
        Debug.Log(hp);
        if (hp <= 0)
        {
            StartCoroutine(Die());
        }
    }
    public void AddHealth(float _value)
    {
        hp = Mathf.Clamp(hp + _value, 0, maxHP);
    }
    public IEnumerator Die()
    {
        Debug.Log("Player died! ");
        //Die animation
        Ani.SetBool("isDead", true);
        //Disable Enemy
        yield return new WaitForSeconds(0.8f);

        isDead = true;
        Ani.SetBool("isDead", false);
        transform.position = respawnPoint;
        AddHealth(maxHP);

        Destroy(parent);
        SceneManager.LoadScene("MainMenu");
        // GetComponent<Collider2D>().enabled = false;
        // GetComponent<Renderer>().enabled = false;
        // this.enabled = false;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDectector")
        {
            transform.position = respawnPoint;
        }
        else if (collision.tag == "Checkpoint")
        {
            Debug.Log("Checkpoint");
            respawnPoint = transform.position;
        }
    }


    public void TakeHit()
    {
        throw new System.NotImplementedException();
    }

}
