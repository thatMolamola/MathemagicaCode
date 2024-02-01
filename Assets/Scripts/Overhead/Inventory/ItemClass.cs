using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemClass: ScriptableObject
{
    public string name;
    public Sprite itemIcon;
    public string itemFunDescription;

    public abstract void useItem();
    public abstract void useConsumeItem();
    public abstract void examineItem();
    public abstract void giveItem();

}
