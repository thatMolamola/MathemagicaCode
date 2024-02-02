using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Number Power Item: can be used to modify spells
[CreateAssetMenu (fileName = "new NP Item", menuName = "Item/NP")]
public class NPItemClass : ItemClass
{
    public int NPValue;
    public string itemUseDescription;
    public bool special;
    public int specialValue;

    public override void useItem() {}
    public override void useConsumeItem() {}
    public override void examineItem() {}
    public override void giveItem() {}
}
