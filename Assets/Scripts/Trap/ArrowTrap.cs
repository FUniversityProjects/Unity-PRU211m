using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public GameObject projectile;

    public Transform spawnLocation; 
    // Start is called before the first frame update

    public Quaternion spawnRotation;

    public float sqawnTime = 4f;

    public float timeSinceSpawned = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timeSinceSpawned += Time.deltaTime;

        if (timeSinceSpawned >= sqawnTime ) {
            Instantiate(projectile,spawnLocation.position , spawnRotation);
            timeSinceSpawned= 0;
        }
    }
}
