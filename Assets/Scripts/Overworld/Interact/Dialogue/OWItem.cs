using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OWItem : OWInteract, ITalkable
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private int keyNum;
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private Inventory playerInventory;

    public override void Interact() {
        Talk(dialogueText);
    }

    public void Talk(DialogueText dialogueText) {
        dialogueController.DisplayNextParagraph(dialogueText);
        if (dialogueController.getConvEnded()) {
            playerInventory.KeyItems.Add(keyNum);
            Destroy(this.gameObject);
        }
    }
}
