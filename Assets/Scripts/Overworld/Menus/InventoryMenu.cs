using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    private Inventory inventoryRfr;
    private NPItem[] NPItems = new NPItem[40];
    private int[] NPItemCounts = new int[40];
    private List<int> NPItemsIndex = new List<int>();

    //List references
    [SerializeField] private Transform listParent;

    //Panel references
    [SerializeField] private Text itemNameP;
    [SerializeField] private Text funInfo;
    [SerializeField] private Text useText;
    [SerializeField] private Text NPText;

    void Start()
    {
        inventoryRfr = Resources.Load<Inventory>("SOs/Dynamic/Inventory");
        NPItems = inventoryRfr.NPItems;
        NPItemCounts = inventoryRfr.NPItemCounts;
        NPItemsIndex = inventoryRfr.NPItemsIndex;
        ListLoad();
    }

    private void ListLoad(){
        foreach (Transform listEntry in listParent) {
            int index = listEntry.GetSiblingIndex();
            if (NPItemsIndex.Count > index) {
                foreach (Transform child in listEntry){
                    if (child.name == "ItemName"){
                        child.GetComponent<Text>().text = NPItems[NPItemsIndex[index]].itemName;
                    }
                    if (child.name == "ItemQuant"){
                        child.GetComponent<Text>().text = "x" + NPItemCounts[NPItemsIndex[index]];
                    }
                }
            } else {
                foreach (Transform child in listEntry){
                    if (child.name == "ItemName"){
                        child.GetComponent<Text>().text = "";
                    }
                    if (child.name == "ItemQuant"){
                        child.GetComponent<Text>().text = "";
                    }
                }
            }
        }
        if (NPItemsIndex.Count > 0) {
            itemNameP.text = NPItems[NPItemsIndex[0]].itemName;
            funInfo.text = NPItems[NPItemsIndex[0]].funDesc;
            useText.text = NPItems[NPItemsIndex[0]].useDesc;
            NPText.text = "NP:" + NPItems[NPItemsIndex[0]].NPValue;
        }
    }

    public void mouseOnInventorySlot(int buttonNum) {
        if (buttonNum < NPItemsIndex.Count) {
            itemNameP.text = NPItems[NPItemsIndex[buttonNum]].itemName;
            funInfo.text = NPItems[NPItemsIndex[buttonNum]].funDesc;
            useText.text = NPItems[NPItemsIndex[buttonNum]].useDesc;
            NPText.text = "NP:" + NPItems[NPItemsIndex[buttonNum]].NPValue;
        }
    }
}
