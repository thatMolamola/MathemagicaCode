using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    public Weapon[] weaponList;
    public int selectedWeapon;

    public bool selectedWeaponAttack(Unit enemyUnit){
        weaponList[selectedWeapon].Attack(enemyUnit);
        return deathCheck(enemyUnit);
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
