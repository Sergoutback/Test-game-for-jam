using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{

    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text dialogueText;
    [SerializeField]
    private GameObject dialogueBox;
    [SerializeField]
    private Text continueText;

    public Queue<string> sentenses;

    // Start is called before the first frame update
    void Start()
    {
        sentenses = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {
        // can animate to display dialogueBox
        Time.timeScale = 0;

        dialogueBox.SetActive(true);
        continueText.text = "Продолжить >>";
        nameText.text = dialogue.name;
        sentenses.Clear();

        foreach (string sentense in dialogue.sentenses) {
            sentenses.Enqueue(sentense);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence() {
        if (sentenses.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentenses.Dequeue();
        // dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        if (sentenses.Count == 0) {
            continueText.text = "Закончить";
        }
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue() {
        dialogueBox.SetActive(false);
        Time.timeScale = 1;
    }



}
