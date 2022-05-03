using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearStrike : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("EnemyHitBox")) {
            col.transform.parent.GetComponent<Enemy>().takeDamage(2);
        }
    }
}
