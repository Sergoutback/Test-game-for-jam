using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public int nextScene;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") {
            GetComponent<DialogueTrigger>().TriggerDialogue();
            StartCoroutine(ChangeScene());
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") {
            GetComponent<DialogueTrigger>().EndDialogue();
        }
    }

    IEnumerator ChangeScene() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextScene);
    }


}
