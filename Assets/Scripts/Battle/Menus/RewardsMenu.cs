using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardsMenu : MonoBehaviour
{
    [SerializeField] private string[] battleRewards;
    private Inventory playerInv;
    [SerializeField] private Text rewardsList;
    private GameObject rewardDisplay;

    void Start() {
        playerInv = Resources.Load<Inventory>("SOs/Dynamic/Inventory");
        rewardDisplay = this.transform.GetChild(0).gameObject;
    }
    
    public void displayRewards(EnemyUnit enemy) {
        rollRewards(enemy);
        rewardDisplay.SetActive(true);
        MenuManage.OpenMenu(Menu.DONE, gameObject);
    }

    private void rollRewards(EnemyUnit enemy) {
        rewardsList.text = "You found ";
        foreach (NPItem reward in enemy.dropTable) {
            if (oddsRolled(reward)){
                playerInv.NPItems.Add(reward);
            }
            rewardsList.text += reward.itemName + ", "; 
        }
        rewardsList.text = rewardsList.text.Substring(0, rewardsList.text.Length - 2);
        rewardsList.text += "!"; 
    }

    public void onLeave() {
        MenuManage.OpenMenu(Menu.DONE, gameObject);
    }

    private bool oddsRolled(NPItem item) {
        float num = Random.Range(0f, 1f);
        if (num < 1/item.spawnChance) {
            return true;
        } else {
            return false;
        }
    }
}
