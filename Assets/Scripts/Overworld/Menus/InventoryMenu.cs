using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    private Inventory inventoryRfr;
    private List<NPItem> NPItems = new List<NPItem>();

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
        ListLoad();
    }

    private void ListLoad(){
        foreach (Transform listEntry in listParent) {
            int index = listEntry.GetSiblingIndex();
            if (NPItems.Count > index) {
                foreach (Transform child in listEntry){
                    if (child.name == "ItemName"){
                        child.GetComponent<Text>().text = NPItems[index].itemName;
                    }
                    if (child.name == "ItemQuant"){
                        child.GetComponent<Text>().text = "x" + NPItems[index].itemCount;
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
        if (NPItems.Count > 0) {
            itemNameP.text = NPItems[0].itemName;
            funInfo.text = NPItems[0].funDesc;
            useText.text = NPItems[0].useDesc;
            NPText.text = "NP:" + NPItems[0].NPValue;
        }
    }

    public void mouseOnInventorySlot(int buttonNum) {
        if (buttonNum < NPItems.Count) {
            itemNameP.text = NPItems[buttonNum].itemName;
            funInfo.text = NPItems[buttonNum].funDesc;
            useText.text = NPItems[buttonNum].useDesc;
            NPText.text = "NP:" + NPItems[buttonNum].NPValue;
        }
    }
}
