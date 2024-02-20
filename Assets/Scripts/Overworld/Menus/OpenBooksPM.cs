using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script updates the open spell book's display based on the player 
// and the current mouse selection of spell
public class OpenBooksPM : MonoBehaviour
{
    [SerializeField] private Transform listParent;
    [SerializeField] private Text weaponDescription;
    [SerializeField] private Text NPText;
    [SerializeField] private GameObject enchantButton;
    private PlayerUnit chosenPlayer;
    private Weapon chosenWeapon;
    private Weapon[] weaponList;

    public void ListLoad(PlayerUnit playerUnit){
        chosenPlayer = playerUnit;
        weaponList = playerUnit.getWeaponList();
        chosenWeapon = weaponList[0];
        foreach (Transform listEntry in listParent) {
            int index = listEntry.GetSiblingIndex();
            listEntry.GetComponent<Text>().text = weaponList[index].thisWeapon.weaponName;
        }
        string npNum = weaponList[0].thisWeapon.currentRealDmgModifier.ToString();
        NPText.text = "NP: " + npNum;
        weaponDescription.text = weaponList[0].thisWeapon.weaponDescription + npNum;
    }

    public void mouseOnInventorySlot(int buttonNum) {
        string npNum = weaponList[buttonNum].thisWeapon.currentRealDmgModifier.ToString();
        NPText.text = "NP: " + npNum;
        weaponDescription.text = weaponList[buttonNum].thisWeapon.weaponDescription + npNum;
        chosenWeapon = weaponList[buttonNum];
        if (!chosenWeapon.thisWeapon.modable) {
            enchantButton.SetActive(false);
        } else {
            enchantButton.SetActive(true);
        }
    }

    public Weapon getWeapon() {
        return chosenWeapon;
    }
}
