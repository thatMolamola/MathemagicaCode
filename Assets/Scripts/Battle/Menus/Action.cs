using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    public string actionChoice;
    public Unit targetUnit;
    public Weapon weaponChoice;

    //ATTACK Constructor
    public Action(Weapon theWeapon, Unit target, string action) {
        setWeapon(theWeapon);
        setTarget(target);
        setAction(action);
    }

    private void setWeapon(Weapon theWeapon) {
        weaponChoice = theWeapon;
    }

    private void setTarget(Unit target) {
        targetUnit = target;
    }

    private void setAction(string action) {
        actionChoice = action;
    }
}