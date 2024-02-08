using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnchantMenu : MonoBehaviour
{
    [SerializeField] private Transform listParent;
    [SerializeField] private Text weaponDescription;
    [SerializeField] private Text NPText;
    private PlayerUnit chosenPlayer;
    private Weapon chosenWeapon;

    public void ListLoad(PlayerUnit playerUnit){
        chosenPlayer = playerUnit;
        chosenWeapon = chosenPlayer.weaponList[0];
        foreach (Transform listEntry in listParent) {
            int index = listEntry.GetSiblingIndex();
            listEntry.GetComponent<Text>().text = playerUnit.weaponList[index].thisWeapon.weaponName;
        }
        NPText.text = "NP: " + playerUnit.weaponList[0].thisWeapon.currentRealDmgModifier.ToString();
        weaponDescription.text = playerUnit.weaponList[0].thisWeapon.weaponDescription;
    }

    public void mouseOnInventorySlot(int buttonNum) {
        NPText.text = "NP: " + chosenPlayer.weaponList[buttonNum].thisWeapon.currentRealDmgModifier.ToString();
        weaponDescription.text = chosenPlayer.weaponList[buttonNum].thisWeapon.weaponDescription;
        chosenWeapon = chosenPlayer.weaponList[buttonNum];
    }

    public Weapon getWeapon() {
        return chosenWeapon;
    }
}
