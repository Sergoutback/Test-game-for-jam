using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStrike : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("EnemyHitBox")) {
            Debug.Log(col.transform.parent.name);
            col.transform.parent.GetComponent<Enemy>().getStunned();
        }
    }

}
