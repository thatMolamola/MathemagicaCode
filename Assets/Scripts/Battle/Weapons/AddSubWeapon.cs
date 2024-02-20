using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSubWeapon : Weapon
{
    public override void Attack (Unit enemyUnit){
        if (thisWeapon.real) {
            if (!thisWeapon.damagingDown) {
                enemyUnit.currentHPReal += thisWeapon.currentRealDmgModifier;
            } else {
                enemyUnit.currentHPReal -= thisWeapon.currentRealDmgModifier;
            }
        } else {
            if (!thisWeapon.damagingDown) {
                enemyUnit.currentHPImag += thisWeapon.currentImagDmgModifier;
            } else {
                enemyUnit.currentHPImag -= thisWeapon.currentImagDmgModifier;
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
                enemyUnit.currentHPReal += 1;
            } else {
                enemyUnit.currentHPReal -= 1;
            }
        } else {
            if (!thisWeapon.damagingDown) {
                enemyUnit.currentHPImag += 1;
            } else {
                enemyUnit.currentHPImag -= 1;
            }
        }
    }
}
