using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Single Use Dialogue Trigger
public class SUDialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private InputSystemController playerController;

    [SerializeField] private bool triggered, runOnce;

    public void Start() {
        runOnce = true;
    }

    public void Update() {
        if (triggered) {
            if (runOnce) {
                dialogueController.DisplayNextParagraph(dialogueText);
                playerController.canMove = false;
                runOnce = false;
            }
            if (Keyboard.current.eKey.wasPressedThisFrame){
                dialogueController.DisplayNextParagraph(dialogueText);
            }
            if (dialogueController.gameObject.activeSelf == false) {
                playerController.canMove = true;
                Destroy(gameObject);
            }
        }  
    }
}
