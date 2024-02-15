using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnchantMenu : MonoBehaviour
{
    [SerializeField] private Transform openBookParent, closedBookParent;
    
    void Start() {
        bookSetup();
    }

    private void bookSetup() {
        closedBookParent.gameObject.SetActive(true);
    }
    
    public void onBookSelect() {
        closedBookParent.gameObject.SetActive(false);
        openBookParent.GetChild(0).gameObject.SetActive(true);
    }

    public void onBackPress() {
        MenuManage.OpenMenu(Menu.MAIN_MENU, gameObject);
    }
}
