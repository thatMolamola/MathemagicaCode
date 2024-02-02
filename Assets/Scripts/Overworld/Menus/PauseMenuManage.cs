using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OWMenu {LOADBEARING, PAUSE_MENU, TEAM, BAG, CRAFT, SAVE}

public static class PauseMenuManage
{
    public static bool IsInitialized { get; private set;}

    public static GameObject pauseMenu, bagMenu, craftMenu, teamMenu, saveMenu;

    public static void Init() {
        GameObject canvas = GameObject.Find("PSubMenus");
        pauseMenu = canvas.transform.Find("PauseMenu").gameObject;
        teamMenu = canvas.transform.Find("Team").gameObject;
        bagMenu = canvas.transform.Find("Bag").gameObject;
        craftMenu = canvas.transform.Find("Craft").gameObject;
        saveMenu = canvas.transform.Find("Save").gameObject;

        IsInitialized = true;
    }

    public static void OpenPauseMenu(OWMenu menu, GameObject callingMenu) {
        if (!IsInitialized) {
            Init();
        }
        switch (menu) 
        {
            case OWMenu.PAUSE_MENU:
                pauseMenu.SetActive(true);
                break;
            case OWMenu.TEAM:
                teamMenu.SetActive(true);
                break;
            case OWMenu.BAG:
                bagMenu.SetActive(true);
                break;
            case OWMenu.CRAFT:
                craftMenu.SetActive(true);
                break;
            case OWMenu.SAVE:
                saveMenu.SetActive(true);
                break;
        }
        callingMenu.SetActive(false);
    }
     
    public static void CloseMenu(GameObject callingMenu) {
        if (!IsInitialized) {
            Init();
        }
        pauseMenu.SetActive(true);
        callingMenu.SetActive(false);
    }
}
