using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    public Weapon[] weaponList;
    public bool fleeFlag, fledSuccess;
    private NPItem chosenItem;

    public void executeAction(Action selectAction) {
        if (selectAction.actionChoice == "ATTACK") {
            selectedWeaponAttack(selectAction.weaponChoice, selectAction.targetUnit);
        }

        if (selectAction.actionChoice == "ENCHANT") {
            selectedEnchant(selectAction.weaponChoice);
        }

        if (selectAction.actionChoice == "FLEE") {
            selectedFlee(selectAction.targetUnit);
        }
    }

    private void selectedWeaponAttack(Weapon weapon, Unit enemyUnit){
        weapon.Attack(enemyUnit);
    }

    private void selectedEnchant(Weapon weapon){
        Debug.Log(weapon.thisWeapon.weaponName);
        Debug.Log(chosenItem.itemName);
        weapon.thisWeapon.currentRealDmgModifier = chosenItem.NPValue;
        weapon.thisWeapon.modded = true;
    }

    private void selectedFlee(Unit enemyUnit){
        fleeFlag = true;
        if (enemyUnit.unitName == "Door") {
            fledSuccess = true;
        }
    }

    public override bool deathCheck(Unit enemyUnit) {
        if (enemyUnit.currentHPReal == 0 && enemyUnit.currentHPImag == 0) {
            return true;
        } else if (currentHPReal < 0 && enemyUnit.currentHPImag == 0){
            negative = true;
            return false;
        } else if (currentHPReal > 0 && enemyUnit.currentHPImag == 0){
            negative = false;
            return false;
        } else {
            return false;
        }
    }

    public void setItem(NPItem item) {
        chosenItem = item;
    }
}
