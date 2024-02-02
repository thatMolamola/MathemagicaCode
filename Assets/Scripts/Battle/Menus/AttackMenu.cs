using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackMenu : MonoBehaviour
{
    public Weapon[] characterWeapons;
    public Text attackDesc;
    public Text attackValue;

    public void onBackPress() {
        MenuManage.OpenMenu(Menu.MAIN_MENU, gameObject);
    }

    public void mouseOnWeaponButton(int buttonNum) {
        string damage = characterWeapons[buttonNum].currentRealDmgModifier.ToString();
        if (characterWeapons[buttonNum].special) {
            attackDesc.text = characterWeapons[buttonNum].weaponDescription; 
        } else {
            attackDesc.text = characterWeapons[buttonNum].weaponDescription + damage;
        }    
        attackValue.text = damage;
    }
}
