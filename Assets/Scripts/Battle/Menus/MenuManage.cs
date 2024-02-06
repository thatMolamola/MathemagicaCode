using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Menu {MAIN_MENU, ATTACK1, ATTACK2, CRAFT, DIALOGUE, REWARD, DONE}

public static class MenuManage
{
    public static bool IsInitialized { get; private set;}

    public static GameObject mainMenu, attackMenu1, attackMenu2, craftMenu, dialogueMenu, rewardMenu;

    public static void Init() {
        GameObject canvas = GameObject.Find("HUDs");
        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        attackMenu1 = canvas.transform.Find("AttackMenu1").gameObject;
        attackMenu2 = canvas.transform.Find("AttackMenu2").gameObject;
        craftMenu = canvas.transform.Find("CraftMenu").gameObject;
        dialogueMenu = canvas.transform.Find("DialogueMenu").gameObject;
        rewardMenu = canvas.transform.Find("RewardMenu").gameObject;

        IsInitialized = true;
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu) {
        int firstWeapon = 0;
        if (!IsInitialized) {
            Init();
        }
        switch (menu) 
        {
            case Menu.MAIN_MENU:
                mainMenu.SetActive(true);
                break;
            case Menu.ATTACK1:
                attackMenu1.SetActive(true);
                attackMenu1.GetComponent<AttackMenu>().mouseOnWeaponButton(firstWeapon);
                break;
            case Menu.ATTACK2:
                attackMenu2.SetActive(true);
                attackMenu2.GetComponent<AttackMenu>().mouseOnWeaponButton(firstWeapon);
                break;
            case Menu.CRAFT:
                craftMenu.SetActive(true);
                break;
            case Menu.DIALOGUE:
                craftMenu.SetActive(true);
                break;
            case Menu.REWARD:
                rewardMenu.SetActive(true);
                break;
            case Menu.DONE:
                IsInitialized = false;
                break;
        }
        callingMenu.SetActive(false);
    }

    public static void CloseMenu(GameObject callingMenu) {
        if (!IsInitialized) {
            Init();
        }
        mainMenu.SetActive(true);
        callingMenu.SetActive(false);
    }
}
