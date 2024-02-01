using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text dialogueTextObject;

    private Queue<string> paragraphs = new Queue<string>();

    private bool conversationEnded;

    private string p;

    public void Start() {
        conversationEnded = false;
    }

    public void DisplayNextParagraph(DialogueText dialogueText) {
        if (paragraphs.Count == 0) {
            if (!conversationEnded) {
                StartConversation(dialogueText);
            } else {
                EndConversation();
                return;
            }
        }

        p = paragraphs.Dequeue();

        dialogueTextObject.text = p; 

        if (paragraphs.Count == 0) {
            conversationEnded = true;
        }
    }

    public bool getConvEnded() {
        return conversationEnded;
    }

    private void StartConversation(DialogueText dialogueText){
        if (!gameObject.activeSelf) {
            gameObject.SetActive(true);
        }

        nameText.text = dialogueText.speakerName;

        for (int i = 0; i < dialogueText.paragraphs.Length; i++) {
            paragraphs.Enqueue(dialogueText.paragraphs[i]);
        }
    }

    private void EndConversation(){
        paragraphs.Clear();
        conversationEnded = false;
        if (gameObject.activeSelf) {
            gameObject.SetActive(false);
        }
    }
}
