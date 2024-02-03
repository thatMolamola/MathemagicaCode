using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FOR THE LOVE THAT IS GOOD AND HOLY, DO NOT CHANGE THE NAMES OF THESE VARIABLES
//Number Power Item: can be used to modify spells
[CreateAssetMenu (fileName = "NPItem", menuName = "Item/NP")]
public class NPItem: ScriptableObject
{
    //On Inventory
    public string itemName;
    public int itemCount;

    //On Inventory Panel
    public string useDesc;
    public string funDesc;
    public Sprite itemSprite;
    public int NPValue;

    //For internal uses
    public bool special;
    public int specialNPValue; 
}
