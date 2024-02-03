using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Number Power Item: can be used to modify spells
[CreateAssetMenu (fileName = "NPItem", menuName = "Item/NP")]
public class NPItem: ScriptableObject
{
    public string itemName;
    public string itemUseDescription;
    public string funDescription;
    public Sprite itemSprite;
    public int NPValue;
    public bool special;
    public int specialNPValue;
}
