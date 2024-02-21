using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSubWeapon : Weapon
{
    public override void Attack (Unit enemyUnit){
        if (thisWeapon.real) {
            if (!thisWeapon.damagingDown) {
                enemyUnit.thisUnit.currentHPReal += thisWeapon.currentRealDmgModifier;
            } else {
                enemyUnit.thisUnit.currentHPReal -= thisWeapon.currentRealDmgModifier;
            }
        } else {
            if (!thisWeapon.damagingDown) {
                enemyUnit.thisUnit.currentHPImag += thisWeapon.currentImagDmgModifier;
            } else {
                enemyUnit.thisUnit.currentHPImag -= thisWeapon.currentImagDmgModifier;
            }
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

    public override void MinAttack (Unit enemyUnit){
        if (thisWeapon.real) {
            if (!thisWeapon.damagingDown) {
                enemyUnit.thisUnit.currentHPReal += 1;
            } else {
                enemyUnit.thisUnit.currentHPReal -= 1;
            }
        } else {
            if (!thisWeapon.damagingDown) {
                enemyUnit.thisUnit.currentHPImag += 1;
            } else {
                enemyUnit.thisUnit.currentHPImag -= 1;
            }
        }
    }
}
