using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FOR THE LOVE THAT IS GOOD AND HOLY, DO NOT CHANGE THE NAMES OF THESE VARIABLES
//Number Power Item: can be used to modify spells
[CreateAssetMenu (fileName = "WeaponItem", menuName = "Item/Weapon")]
public class WeaponItem : ScriptableObject
{
    //Weapon-Specific Variable stats
    public int currentRealDmgModifier;
    public int currentImagDmgModifier;
    public int ModDurationLeft;
    public bool modded;

    //Weapon-Specific Constant Stats
    public bool permMod;
    public bool modable;
    public int baseRealDmgModifier;
    public int baseImagDmgModifier;
    public int MaxModDuration;
    public bool real;
    public bool damagingDown;

    public bool special;

    public string weaponName;
    public string weaponDescription;
}
