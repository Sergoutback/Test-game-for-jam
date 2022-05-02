using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        // replace sprite to blood?

        GameObject.Find("GameOverDialog").GetComponent<DialogueTrigger>().TriggerDialogue();
        StartCoroutine(ReloadCoroutine());
    }

    IEnumerator ReloadCoroutine() {
        yield return new WaitForSeconds(1);
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
