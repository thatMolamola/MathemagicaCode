using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OWKeyDepend : OWInteract, ITalkable, IAnimateControl, IKeyAdd
{
    [SerializeField] private DialogueText dialogueTextFail, dialogueTextSuccess;
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private Inventory playerInv;
    [SerializeField] private Animator interactible;
    [SerializeField] private int KeyItemNumCheck;
    [SerializeField] private int KeyItemNumGive;
    [SerializeField] private CombatPrefabRefer CPR;
    [SerializeField] private GameObject allyCombatPrefab;

    public override void Interact() {
        if (playerInv.KeyItems.Contains(KeyItemNumCheck)) {
            AnimateChange(interactible);
            Talk(dialogueTextSuccess);
            if (dialogueController.getConvEnded()) {
                ComponentsStateChange();
                KeyItemAdd(KeyItemNumGive);
            }
        } else {
            Talk(dialogueTextFail);
        }
    }

    public void KeyItemAdd(int num) {
        playerInv.KeyItems.Add(num);
    }

    public void Talk(DialogueText dialogueText) {
        dialogueController.DisplayNextParagraph(dialogueText);
    }

    public void AnimateChange(Animator i) {
        i.SetBool("Triggered", true);
    }

    public void ComponentsStateChange(){
        this.GetComponent<AllyFollow>().enabled = true;
        Destroy(this.gameObject.transform.GetChild(0).gameObject);
        this.enabled = false;
        CPR.allyTeam.Add(allyCombatPrefab);
    }
}
