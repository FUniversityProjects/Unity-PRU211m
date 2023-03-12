using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathway : MonoBehaviour
{
    [SerializeField] private GameObject[] pathways ;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f; 
    

    
    
    private void Update()
    {
        if (Vector2.Distance(pathways[currentWaypointIndex].transform.position, transform.position) < 1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= pathways.Length)
            {
                currentWaypointIndex= 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, pathways[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        
    }
}
