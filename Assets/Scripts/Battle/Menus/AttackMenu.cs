using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackMenu : MonoBehaviour
{
    public Weapon[] characterWeapons;
    public Text attackDesc;
    public Text attackValue;
    public Transform buttonParent;

    void Start() {
        nameAttackButtons();
    }

    public void onBackPress() {
        MenuManage.OpenMenu(Menu.MAIN_MENU, gameObject);
    }

    public void mouseOnWeaponButton(int buttonNum) {
        string damage = characterWeapons[buttonNum].thisWeapon.currentRealDmgModifier.ToString();
        if (characterWeapons[buttonNum].thisWeapon.special) {
            attackDesc.text = characterWeapons[buttonNum].thisWeapon.weaponDescription; 
        } else {
            attackDesc.text = characterWeapons[buttonNum].thisWeapon.weaponDescription + damage;
        }    
        attackValue.text = damage;
    }

    private void nameAttackButtons() {
        foreach (Transform button in buttonParent) {
            Text weaponName = button.GetComponentInChildren<Text>();
            weaponName.text = characterWeapons[button.GetSiblingIndex()].thisWeapon.weaponName;
        }
    }
}
