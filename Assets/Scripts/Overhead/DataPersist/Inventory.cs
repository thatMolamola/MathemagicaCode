using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Inventory", menuName = "Item/Inventory")]
public class Inventory : ScriptableObject
{
    public NPItem[] NPItems = new NPItem[40]; //contains all 40 Items in a predetermined order, no Counts
    public int[] NPItemCounts = new int[40];  //contains the counts of all 40 items in a predetermined order
    public List<int> NPItemsIndex = new List<int>(); //contains the ID numbers of items we have
    public List<int> KeyItems = new List<int>();
}
