using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Inventory", menuName = "Item/Inventory")]
public class Inventory : ScriptableObject
{
    public NPItem[] NPItems; 
}
