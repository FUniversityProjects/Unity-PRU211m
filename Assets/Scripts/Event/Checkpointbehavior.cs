using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpointbehavior : MonoBehaviour
{
    // have we been triggered?
    bool triggered;
    void Awake()
    {
        triggered = false;
    }
    // called whenever another collider enters our zone (if layers match)
    void OnTriggerEnter2D(Collider2D collider)
    {
        // check we haven't been triggered yet!
        if (!triggered)
        {

            if (collider.gameObject.layer
                == LayerMask.NameToLayer("Player"))
            {
                Trigger();
            }
        }
    }
    void Trigger()
    {
        // Tell the animation controller about our 
        // recent triggering
        GetComponent<Animator>().SetTrigger("Triggered");
        triggered = true;
    }
}
