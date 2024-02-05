using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OWMenu {LOADBEARING, PAUSE_MENU, TEAM, BAG, CRAFT, SAVE, QUIT}

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
        if (callingMenu != null){
            if (!IsInitialized) {
                Init();
            }
            pauseMenu.SetActive(false);
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
                case OWMenu.QUIT:
                    IsInitialized = false;
                    break;
            }
        }
    }
     
    public static void CloseSubmenu(OWMenu menu, GameObject callingMenu) {
        if (!IsInitialized) {
            Init();
        }
        pauseMenu.SetActive(true);
        switch (menu) 
        {
            case OWMenu.PAUSE_MENU:
                pauseMenu.SetActive(false);
                break;
            case OWMenu.TEAM:
                teamMenu.SetActive(false);
                break;
            case OWMenu.BAG:
                bagMenu.SetActive(false);
                break;
            case OWMenu.CRAFT:
                craftMenu.SetActive(false);
                break;
            case OWMenu.SAVE:
                saveMenu.SetActive(false);
                break;
        }
    }
}
