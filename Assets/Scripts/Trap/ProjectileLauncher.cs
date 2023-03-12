using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    // Start is called before the first frame update
    public float  moveSpeed = 3f;

    public float timeToLive = 3f;

    private float timeSinceSqawned = 0f;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveSpeed * transform.right * Time.deltaTime;

        timeSinceSqawned+= Time.deltaTime;
        if(timeSinceSqawned > timeToLive)
        {
            Destroy(gameObject);
        }
    }
}
