using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTriggerOnLoad : MonoBehaviour
{

    public int nextScene;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayCoroutine());
        // run another coroutine to change scene with a delay - it should change after the dialog
        StartCoroutine(ChangeScene());
    }

    IEnumerator DelayCoroutine() {
        yield return new WaitForSeconds(0.5f);
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    IEnumerator ChangeScene() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextScene);
    }

}
