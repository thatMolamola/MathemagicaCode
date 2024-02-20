using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionResponse
{
    private Action action;
    private string actionDialogue;
    private float actionDamage;
    private bool actionSuccess;

    public ActionResponse(Action action, float damage, string dialogue, bool success) {
        setDamage(damage);
        setDialogue(dialogue);
        setSuccess(success);
        setAction(action);
    }

    public float getDamage() {
        return actionDamage;
    }

    public string getDialogue() {
        return actionDialogue;
    }

    public bool getSuccess() {
        return actionSuccess;
    }

    public Action getAction() {
        return action;
    }

    private void setSuccess(bool success) {
        actionSuccess = success;
    }

    private void setAction(Action actionReceived) {
        action = actionReceived;
    }

    private void setDamage(float damage) {
        actionDamage = damage;
    }

    private void setDialogue(string dialogue) {
        actionDialogue = dialogue;
    }
}