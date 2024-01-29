using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMenu : MonoBehaviour
{
    public void onDialogueTrigger() {
        MenuManage.OpenMenu(Menu.DIALOGUE, gameObject);
    }

    //TO-DO: Dialogue Menu should move from dialogue to dialogue until it ends
    /*
    public void nextDialogueUnit() {

    }
    */
}
