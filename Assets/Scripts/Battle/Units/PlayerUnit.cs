using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    public Weapon[] weaponList;
    public int selectedWeapon;

    public bool executeAction(Action selectAction) {
        if (selectAction.actionChoice == "ATTACK") {
            return selectedWeaponAttack(selectAction.weaponChoice, selectAction.targetUnit);
        }

        if (selectAction.actionChoice == "CRAFT") {
            selectedCraft();
            return false;
        }

        if (selectAction.actionChoice == "FLEE") {
            selectedFlee();
            return false;
        }

        return false;
    }

    public bool selectedWeaponAttack(Weapon weapon, Unit enemyUnit){
        weapon.Attack(enemyUnit);
        return deathCheck(enemyUnit);
    }

    public void selectedCraft(){
        //TODO
    }

    public void selectedFlee(){
        //TODO
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
}
