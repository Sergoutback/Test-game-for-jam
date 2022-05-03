using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health = 10;
    private int maxHealth;
    public Slider slider;

    private AudioSource[] audioSources;

    void Start() {
        audioSources = GetComponents<AudioSource>();
        maxHealth = health;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        slider.fillRect.GetComponentInChildren<Image>().color = Color.red;
    }

    public void takeDamage(int damage)
    {
        audioSources[1].Play();
        health -= damage;
        slider.value = health;

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
        yield return new WaitForSeconds(0.1f);
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
