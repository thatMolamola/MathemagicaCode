using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardsMenu : MonoBehaviour
{
    [SerializeField] private string[] battleRewards;
    [SerializeField] private Inventory playerInv;
    [SerializeField] private Text rewardsList;
    [SerializeField] private GameObject rewardDisplay;
    
    public void displayRewards(EnemyUnit enemy) {
        rollRewards(enemy);
        rewardDisplay.SetActive(true);
        }

    private void rollRewards(EnemyUnit enemy) {
        rewardsList.text = "You found ";
        foreach (int rewardIndex in enemy.dropTable) {
            if (oddsRolled(rewardIndex)){
                playerInv.NPItemCounts[rewardIndex] += 1;
                if (!playerInv.NPItemsIndex.Contains(rewardIndex)) {
                    playerInv.NPItemsIndex.Add(rewardIndex);
                }
            }
            rewardsList.text += playerInv.NPItems[rewardIndex].itemName + ", "; 
        }
        rewardsList.text = rewardsList.text.Substring(0, rewardsList.text.Length - 2);
        rewardsList.text += "!"; 
    }

    public void onLeave() {
        MenuManage.OpenMenu(Menu.DONE, gameObject);
    }

    private bool oddsRolled(int itemIndex) {
        float num = Random.Range(0f, 1f);
        if (num < 1/playerInv.NPItems[itemIndex].spawnChance) {
            return true;
        } else {
            return false;
        }
    }
}
