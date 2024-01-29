using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void onAttackPress() {
       MenuManage.OpenMenu(Menu.ATTACK, gameObject);
    }

    public void onCraftPress() {
        MenuManage.OpenMenu(Menu.CRAFT, gameObject);
    }
}
