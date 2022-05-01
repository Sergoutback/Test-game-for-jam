using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("BulletClone"))
    //     {
    //         health -= 1;
    //         text.text = health.ToString();
    //     }
    // }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
