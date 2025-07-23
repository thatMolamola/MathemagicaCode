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

    [SerializeField] private AllyFollow aFollow;

    public override void Interact() {
        if (playerInv.KeyItems.Contains(KeyItemNumCheck)) {
            AnimateChange();
            Talk(dialogueTextSuccess);
            if (dialogueController.getConvEnded()) {
                KeyItemAdd(KeyItemNumGive);
                StartCoroutine(ComponentsStateChange());
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

    public void AnimateChange() {
        interactible.enabled = true;
        interactible.SetBool("Triggered", true);
        aFollow.active = true;
    }

    private IEnumerator ComponentsStateChange(){
        yield return new WaitForSeconds(1f);
        interactible.SetBool("PermaActive", true);
        interactible.SetBool("Triggered", false);
        this.GetComponent<AllyFollow>().enabled = true;
        Destroy(this.gameObject.transform.GetChild(0).gameObject);
        CPR.allyTeam.Add(allyCombatPrefab);
        this.enabled = false;
        
    }
}
