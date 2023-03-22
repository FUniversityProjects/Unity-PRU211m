using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    [SerializeField] private Transform monster;
    [SerializeField] private Vector2 controlPos;



    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(monster.position.x + controlPos.x, monster.position.y + controlPos.y, 0f);
    }
}
