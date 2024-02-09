using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script should open the Enchant Panel and give it the chosen weapon.
public class InvFromEnchant : MonoBehaviour
{    
    [SerializeField] private OpenBooksPM playerBook;
    [SerializeField] private GameObject spellBook, enchantPanelObj;
    [SerializeField] private EnchantPanel enchantPanel;

    public void enchantPanelOpen() {
        enchantPanelObj.SetActive(true);
        onWeaponSet();
        spellBook.SetActive(false);
    }

    public void enchantPanelClose() {
        enchantPanelObj.SetActive(false);
    }

    public void onWeaponSet() {
        enchantPanel.setWeapon(playerBook.getWeapon());
    }
}
