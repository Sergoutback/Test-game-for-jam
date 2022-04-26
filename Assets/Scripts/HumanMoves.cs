using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMoves : MonoBehaviour
{
    public Transform player;
    public float movementSpeed = 10;
    public float runAwaySpeed = 5;

    void Start()
    {
        
    }

    void Update()
    {
        //Human приближается к Player
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.position, step);

        //if (transform.position == player.position)
        //    OntriggerEnter2d();
        OntriggerEnter2d();
    }

    public void OntriggerEnter2d()
    {
        HumanRunAway();
    }
    public void HumanRunAway()
    {
        Vector3 direction = transform.position - player.position;
        direction = Vector3.Normalize(direction);
        //direction.x = 0;
        //adirection.z = 0;
        transform.rotation = Quaternion.Euler(direction);
        transform.Translate(transform.right * runAwaySpeed);
        
    }
}
