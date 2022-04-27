using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMoves : MonoBehaviour
{
    public Transform player;
    public float movementSpeed = 10;
    public float runAwaySpeed = 1;

    public bool runAway = false;

    void Start()
    {
        
    }

    void Update()
    {
        HumanRunTowards();
    }

    public void HumanRunTowards()
    {
        //Human приближается к Player
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.position, step);

        if (runAway)
        {
            HumanRunAway();
        }
    }
    public void HumanRunAway()
    {
        Vector3 direction = transform.position - player.position;

        direction = Vector3.Normalize(direction);

        (float, float, float) eulerAngles = (Random.Range(0, 360), Random.Range(0, 360), 0f);

        transform.Translate(direction * runAwaySpeed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // HumanRunAway();
            if (collider.gameObject.transform.position.x > gameObject.transform.position.x)
            {
                runAway = true;
            }
        }
    }
}
