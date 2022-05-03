using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrike : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            col.GetComponent<Player>().takeDamage(1);
        }
    }
}
