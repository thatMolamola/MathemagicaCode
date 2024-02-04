using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    public Weapon[] weaponList;
    public int selectedWeapon;

    public int executeAction(Action selectAction) {
        if (selectAction.actionChoice == "ATTACK") {
            selectedWeaponAttack(selectAction.weaponChoice, selectAction.targetUnit);
            return selectAction.weaponChoice.thisWeapon.currentRealDmgModifier;  //will need to be fixed later
        }

        if (selectAction.actionChoice == "CRAFT") {
            selectedCraft();
            return 0;
        }

        if (selectAction.actionChoice == "FLEE") {
            selectedFlee();
            return 0;
        }

        return 0;
    }

    public void selectedWeaponAttack(Weapon weapon, Unit enemyUnit){
        weapon.Attack(enemyUnit);
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
