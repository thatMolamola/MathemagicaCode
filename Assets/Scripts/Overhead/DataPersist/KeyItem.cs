using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "KeyItem", menuName = "Item/Key Item")]
public class KeyItem : ScriptableObject
{
    //On Inventory
    public string itemName;

    //On Inventory Panel
    public string useDesc;
    public Sprite itemSprite;

    public int itemIDNum;
}
