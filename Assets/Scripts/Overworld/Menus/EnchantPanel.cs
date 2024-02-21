using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this script controls the Enchant Panel, which appears on the Inventory tab when enchanting
public class EnchantPanel : MonoBehaviour
{
    private Weapon selectedWeapon;
    private NPItem selectedItem;
    [SerializeField] private Inventory playerInv;
    [SerializeField] private Text enchantPrompt;
    
    void Start() {
        enchantPanelLoad(0);
    }

    public void enchantPanelLoad(int buttonNum) {
        if (this.gameObject.activeInHierarchy){
            if (buttonNum < playerInv.NPItemsIndex.Count) {
                selectedItem = playerInv.NPItems[playerInv.NPItemsIndex[buttonNum]];
                enchantPrompt.text = "Enchant " + selectedWeapon.thisWeapon.weaponName + " with the power of " + selectedItem.itemName + "?";
            }
        }    
    }

    public void EnchantWeapon() {
        int ID = selectedItem.itemID;
        if (playerInv.NPItemCounts[ID] > 0) {
            selectedWeapon.thisWeapon.modder = selectedItem;
            selectedWeapon.thisWeapon.modded = true;
            if (selectedWeapon.thisWeapon.real) {
                selectedWeapon.thisWeapon.currentRealDmgModifier = selectedItem.NPValue;
            } else {
                selectedWeapon.thisWeapon.currentImagDmgModifier = selectedItem.NPValue;
            }   

            playerInv.NPItemCounts[ID] -= 1;
            if (playerInv.NPItemCounts[ID] == 0) {
                playerInv.NPItemsIndex.Remove(ID);
            }
        }
    }

    public void onItemSelect(int buttonNum) {
        if (buttonNum < playerInv.NPItemsIndex.Count) {
            selectedItem = playerInv.NPItems[playerInv.NPItemsIndex[buttonNum]];
        }
    }

    public void setWeapon(Weapon weaponChoice) {
        selectedWeapon = weaponChoice;
    }

    public Weapon getWeapon() {
        return selectedWeapon;
    }

    public NPItem getItem() {
        return selectedItem;
    }
}
