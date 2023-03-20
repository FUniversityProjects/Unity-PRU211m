using Scripts.Interfaces;
using UnityEngine;

public class DamagePlayer : MonoBehaviour, ICollisionHandler
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // call takeDamage Player here
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // call takeDamage Player here
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        // out sight
    }
}
