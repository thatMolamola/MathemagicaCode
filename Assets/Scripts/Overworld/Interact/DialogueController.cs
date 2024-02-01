using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text dialogueTextObject;
    [SerializeField] private Image spriteObject;

    private Queue<string> paragraphs = new Queue<string>();
    private Queue<Sprite> sprites = new Queue<Sprite>();

    private bool conversationEnded;

    private string p;
    private Sprite s;

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
        s = sprites.Dequeue();

        dialogueTextObject.text = p; 
        spriteObject.sprite = s;

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
            sprites.Enqueue(dialogueText.images[i]);
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
