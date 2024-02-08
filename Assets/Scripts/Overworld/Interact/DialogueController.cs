using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text dialogueTextObject;
    [SerializeField] private Image spriteObject;

    [SerializeField] private InputSystemController ISC;

    private Queue<string> names = new Queue<string>();
    private Queue<string> paragraphs = new Queue<string>();
    private Queue<Sprite> sprites = new Queue<Sprite>();

    private bool conversationEnded;

    private string p;
    private Sprite s;
    private string n;

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

        n = names.Dequeue();
        p = paragraphs.Dequeue();
        s = sprites.Dequeue();

        nameText.text = n;
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
        ISC.canMove = false;
        if (!gameObject.activeSelf) {
            gameObject.SetActive(true);
        }

        for (int i = 0; i < dialogueText.paragraphs.Length; i++) {
            paragraphs.Enqueue(dialogueText.paragraphs[i]);
            sprites.Enqueue(dialogueText.images[i]);
            names.Enqueue(dialogueText.speakerNames[i]);
        }
    }

    private void EndConversation(){
        paragraphs.Clear();
        conversationEnded = false;
        ISC.canMove = true;
        if (gameObject.activeSelf) {
            gameObject.SetActive(false);
        }

    }
}
