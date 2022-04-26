using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMoves : MonoBehaviour
{
    public Transform player;
    public float movementSpeed = 10;

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
    }

    public void OntriggerEnter2d(Collider player)
    {
        transform.position = Vector3.zero;
    }
}
