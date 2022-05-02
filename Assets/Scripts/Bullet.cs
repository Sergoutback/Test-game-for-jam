using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("EnemyHitBox")) {
            col.transform.parent.GetComponent<Enemy>().takeDamage(1);
            Destroy(gameObject);
            
        }
    }

}
