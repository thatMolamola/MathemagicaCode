using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//real-only weapon
public class MultipleOfWeapon : Weapon
{
    public override void Attack (Unit enemyUnit){
        float dividedReal = enemyUnit.currentHPReal / thisWeapon.currentRealDmgModifier;
        float dividedImag = enemyUnit.currentHPImag / thisWeapon.currentRealDmgModifier;
        if (dividedReal % 1 == 0) {
            enemyUnit.currentHPReal = (dividedReal - 1) * thisWeapon.currentRealDmgModifier;
        } else {
            enemyUnit.currentHPReal = thisWeapon.currentRealDmgModifier * Mathf.Floor(dividedReal);
        }

        if (dividedImag % 1 == 0) {
            enemyUnit.currentHPImag = (dividedImag - 1) * thisWeapon.currentRealDmgModifier;
        } else {
            enemyUnit.currentHPImag = thisWeapon.currentRealDmgModifier * Mathf.Floor(dividedImag);
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
