using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OWKeyDepend : OWInteract, ITalkable
{
    [SerializeField] private DialogueText dialogueTextFail, dialogueTextSuccess;
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private Inventory playerInv;
    [SerializeField] private int KeyItemNum;

    public override void Interact() {
        if (playerInv.KeyItems.Contains(KeyItemNum)) {
            Talk(dialogueTextSuccess);
        } else {
            Talk(dialogueTextFail);
        }
    }

    public void Talk(DialogueText dialogueText) {
        dialogueController.DisplayNextParagraph(dialogueText);
    }
}
