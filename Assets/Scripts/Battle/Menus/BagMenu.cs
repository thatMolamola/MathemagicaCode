using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagMenu : MonoBehaviour
{
    public void onBackPress() {
        MenuManage.OpenMenu(Menu.MAIN_MENU, gameObject);
    }
}
