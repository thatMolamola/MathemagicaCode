using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void onAttack1Press() {
       MenuManage.OpenMenu(Menu.ATTACK1, gameObject);
    }

    public void onAttack2Press() {
       MenuManage.OpenMenu(Menu.ATTACK2, gameObject);
    }

    public void onCraftPress() {
        MenuManage.OpenMenu(Menu.CRAFT, gameObject);
    }
}
