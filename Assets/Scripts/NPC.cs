using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") {
            GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") {
            GetComponent<DialogueTrigger>().EndDialogue();
        }
    }
}
