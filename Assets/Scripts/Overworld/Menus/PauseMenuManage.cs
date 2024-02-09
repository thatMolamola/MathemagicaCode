using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OWMenu {PAUSE_MENU, TEAM, BAG, ENCHANT, SAVE, QUIT}

public static class PauseMenuManage
{
    public static bool IsInitialized { get; private set;}

    public static GameObject pauseMenu, bagMenu, enchantMenu, teamMenu, saveMenu;

    public static void Init() {
        GameObject canvas = GameObject.Find("PSubMenus");
        pauseMenu = canvas.transform.Find("PauseMenu").gameObject;
        bagMenu = canvas.transform.Find("Bag").gameObject;
        enchantMenu = canvas.transform.Find("Enchant").gameObject;
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
                case OWMenu.BAG:
                    bagMenu.SetActive(true);
                    break;
                case OWMenu.ENCHANT:
                    enchantMenu.SetActive(true);
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
            case OWMenu.BAG:
                bagMenu.SetActive(false);
                break;
            case OWMenu.ENCHANT:
                enchantMenu.SetActive(false);
                break;
            case OWMenu.SAVE:
                saveMenu.SetActive(false);
                break;
        }
    }
}
