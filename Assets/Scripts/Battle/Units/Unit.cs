using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this class describes a unit in battle, either primary player, enemy, ally or boss
public abstract class Unit: MonoBehaviour {

    //Eventually, the goal will be to store all unit data within the UnitData Scriptable Object
    public UnitData thisUnit;
}

