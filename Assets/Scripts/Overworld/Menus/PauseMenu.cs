using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private bool pausedOpen;
    [SerializeField] private SceneControl sc;
    [SerializeField] private InputSystemController ISC;

    void Start () {
        pausedOpen = false;
    }

    void Update () {
        if (Keyboard.current.pKey.wasPressedThisFrame){
            if (!pausedOpen) {
                openPause();
                StartCoroutine(SetPauseState(true));
                ISC.canMove = false;
            } else {
                closePause();
                StartCoroutine(SetPauseState(false));
                ISC.canMove = true;
            }
        }
    }

    private IEnumerator SetPauseState (bool pauseState) {
        yield return new WaitForSeconds(1f);
        pausedOpen = pauseState;
    }

    public void openPause() {
        PauseMenuManage.OpenPauseMenu(OWMenu.PAUSE_MENU, gameObject);
    }

    public void closePause() {
        PauseMenuManage.CloseSubmenu(OWMenu.PAUSE_MENU, gameObject);
    }

    public void onTeamPress(){
        PauseMenuManage.OpenPauseMenu(OWMenu.TEAM, gameObject);
    }

    public void onBagPress(){
        PauseMenuManage.OpenPauseMenu(OWMenu.BAG, gameObject);
    }

    public void closeBag(){
        PauseMenuManage.CloseSubmenu(OWMenu.BAG, gameObject);
    }

    public void onCraftPress(){
        PauseMenuManage.OpenPauseMenu(OWMenu.CRAFT, gameObject);
    }

    public void onEnchantPress(){
        PauseMenuManage.OpenPauseMenu(OWMenu.BAG, gameObject);
        PauseMenuManage.CloseSubmenu(OWMenu.CRAFT, gameObject);
    }

    public void closeCraft(){
        PauseMenuManage.CloseSubmenu(OWMenu.CRAFT, gameObject);
    }

    public void onSavePress(){
        PauseMenuManage.OpenPauseMenu(OWMenu.SAVE, gameObject);
    }

    public void onQuitPress(){
        PauseMenuManage.OpenPauseMenu(OWMenu.QUIT, gameObject);
        sc.SceneLoad("MMMenu");
    }
}
