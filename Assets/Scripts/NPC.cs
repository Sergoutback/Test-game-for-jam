using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    void Start() {
        //
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") {
            GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        Debug.Log("OnCollisionEnter2D");
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") {
            GetComponent<DialogueTrigger>().EndDialogue();
            Debug.Log("OnCollisionExit2D");
        }
    }
}
