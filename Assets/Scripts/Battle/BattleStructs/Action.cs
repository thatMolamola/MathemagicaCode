using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    private string actionChoice;
    private Unit targetUnit;
    private Weapon weaponChoice;

    //ATTACK Constructor
    public Action(Weapon theWeapon, Unit target, string action) {
        setWeapon(theWeapon);
        setTarget(target);
        setAction(action);
    }


    public Weapon getWeapon() {
        return weaponChoice;
    }

    public Unit getTarget() {
        return targetUnit;
    }

    public string getAction() {
        return actionChoice;
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