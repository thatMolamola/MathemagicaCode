using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleOfWeapon : Weapon
{
    public override void Attack (Unit enemyUnit){
        float divided = enemyUnit.currentHPReal / thisWeapon.currentRealDmgModifier;
        if (divided % 1 == 0) {
            enemyUnit.currentHPReal = (divided - 1) * thisWeapon.currentRealDmgModifier;
        } else {
            enemyUnit.currentHPReal = thisWeapon.currentRealDmgModifier * Mathf.Floor(divided);
        }
        if (!thisWeapon.permMod) {
            if (thisWeapon.modded) {
                thisWeapon.ModDurationLeft -= 1; 
                if (thisWeapon.ModDurationLeft == 0) {
                    thisWeapon.currentRealDmgModifier = thisWeapon.baseRealDmgModifier;
                    thisWeapon.ModDurationLeft = thisWeapon.MaxModDuration;
                    thisWeapon.modded = false;
                }
            }
        }
    }
}
