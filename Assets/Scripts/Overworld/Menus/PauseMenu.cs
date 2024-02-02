using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    void Update () {
        if (Keyboard.current.pKey.wasPressedThisFrame){
            openPause();
        }
    }

    public void openPause() {
        PauseMenuManage.OpenPauseMenu(OWMenu.PAUSE_MENU, gameObject);
    }

    public void onTeamPress(){
        PauseMenuManage.OpenPauseMenu(OWMenu.TEAM, gameObject);
    }

    public void onBagPress(){
        PauseMenuManage.OpenPauseMenu(OWMenu.BAG, gameObject);
    }

    public void onCraftPress(){
        PauseMenuManage.OpenPauseMenu(OWMenu.CRAFT, gameObject);
    }

    public void onSavePress(){
        PauseMenuManage.OpenPauseMenu(OWMenu.SAVE, gameObject);
    }
}
