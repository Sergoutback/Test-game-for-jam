using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 10;
    public Text healthText;

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

    public void takeDamage(int damage)
    {
        Debug.Log(damage + " damage to the player!");
        health -= damage;
        healthText.text = "HP: " + health;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        // freeze time or move to menu
    }
}
