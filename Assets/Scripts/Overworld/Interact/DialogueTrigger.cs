using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueController dialogueController;

    // Start is called before the first frame update
    void Start()
    {
        dialogueController.DisplayNextParagraph(dialogueText);
    }

    public void Update() {
        if (Keyboard.current.eKey.wasPressedThisFrame){
            dialogueController.DisplayNextParagraph(dialogueText);
        }
    }
}
