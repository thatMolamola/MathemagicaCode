using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMenu : MonoBehaviour
{
    public void onBackPress() {
        MenuManage.OpenMenu(Menu.MAIN_MENU, gameObject);
    }
}
