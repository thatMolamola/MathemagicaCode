using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this script controls the inventory page display
public class InvMenu : MonoBehaviour
{
    [SerializeField] private Inventory inventoryRfr;
    private NPItem[] NPItems = new NPItem[40];
    private int[] NPItemCounts = new int[40];
    private List<int> NPItemsIndex = new List<int>();

    //List references
    [SerializeField] private Transform listParent;
    [SerializeField] private GameObject enchantPanel;

    //Panel references
    [SerializeField] private Text itemNameP;
    [SerializeField] private Text funInfo;
    [SerializeField] private Text useText;
    [SerializeField] private Text NPText;

    private NPItem selectItem;
    private int invCursorNum;

    void Start()
    {
        //inventoryRfr = Resources.Load<Inventory>("SOs/Dynamic/Inventory");
        NPItems = inventoryRfr.NPItems;
        NPItemCounts = inventoryRfr.NPItemCounts;
        NPItemsIndex = inventoryRfr.NPItemsIndex;
        invCursorNum = 0;
        ListLoad();
    }

    public void ListLoad(){
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
            selectItem = NPItems[NPItemsIndex[0]];
        }
    }

    public void mouseOnInventorySlot(int buttonNum) {
        if (buttonNum < NPItemsIndex.Count) {
            listParent.GetChild(invCursorNum).GetChild(2).gameObject.SetActive(false);
            itemNameP.text = NPItems[NPItemsIndex[buttonNum]].itemName;
            funInfo.text = NPItems[NPItemsIndex[buttonNum]].funDesc;
            useText.text = NPItems[NPItemsIndex[buttonNum]].useDesc;
            NPText.text = "NP:" + NPItems[NPItemsIndex[buttonNum]].NPValue;
            listParent.GetChild(buttonNum).GetChild(2).gameObject.SetActive(true);
            selectItem = NPItems[NPItemsIndex[buttonNum]];
            invCursorNum = buttonNum;
        }
    }

    public NPItem getItem() {
        return selectItem;
    }

    public void closeEnchant() {
        enchantPanel.SetActive(false);
    }

    public void itemEnchanted() {
        StartCoroutine (DelayCloseEnchant());
    }

    private IEnumerator DelayCloseEnchant() {
        yield return new WaitForSeconds(.25f);
        enchantPanel.SetActive(false);
    }
}
