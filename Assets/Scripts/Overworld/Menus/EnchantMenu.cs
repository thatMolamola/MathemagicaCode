using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnchantMenu : MonoBehaviour
{
    public Transform listParent;
    public Text weaponDescription;
    public Text NPText;
    private PlayerUnit chosenPlayer;

    public void ListLoad(PlayerUnit playerUnit){
        chosenPlayer = playerUnit;
        Debug.Log(playerUnit.unitName + " List Loaded");
        foreach (Transform listEntry in listParent) {
            int index = listEntry.GetSiblingIndex();
            Debug.Log(index.ToString());
            listEntry.GetComponent<Text>().text = playerUnit.weaponList[index].thisWeapon.weaponName;
            Debug.Log(playerUnit.weaponList[index].thisWeapon.weaponName);
        }
        NPText.text = "NP: " + playerUnit.weaponList[0].thisWeapon.currentRealDmgModifier.ToString();
        weaponDescription.text = playerUnit.weaponList[0].thisWeapon.weaponDescription;
        Debug.Log("done");
    }

    public void mouseOnInventorySlot(int buttonNum) {
        NPText.text = "NP: " + chosenPlayer.weaponList[buttonNum].thisWeapon.currentRealDmgModifier.ToString();
        weaponDescription.text = chosenPlayer.weaponList[buttonNum].thisWeapon.weaponDescription;
    }
}
