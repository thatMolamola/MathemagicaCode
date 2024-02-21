using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//real-only weapon
public class MultipleOfWeapon : Weapon
{
    public override void Attack (Unit enemyUnit){
        float dividedReal = enemyUnit.thisUnit.currentHPReal / thisWeapon.currentRealDmgModifier;
        float dividedImag = enemyUnit.thisUnit.currentHPImag / thisWeapon.currentRealDmgModifier;
        if (dividedReal % 1 == 0) {
            enemyUnit.thisUnit.currentHPReal = (dividedReal - 1) * thisWeapon.currentRealDmgModifier;
        } else {
            enemyUnit.thisUnit.currentHPReal = thisWeapon.currentRealDmgModifier * Mathf.Floor(dividedReal);
        }

        if (dividedImag % 1 == 0) {
            enemyUnit.thisUnit.currentHPImag = (dividedImag - 1) * thisWeapon.currentRealDmgModifier;
        } else {
            enemyUnit.thisUnit.currentHPImag = thisWeapon.currentRealDmgModifier * Mathf.Floor(dividedImag);
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
