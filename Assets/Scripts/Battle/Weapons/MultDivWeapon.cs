using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultDivWeapon : Weapon
{
    public override void Attack (Unit enemyUnit){
        if (thisWeapon.real) {
            if (!thisWeapon.damagingDown) {
                enemyUnit.currentHPReal *= thisWeapon.currentRealDmgModifier;
                enemyUnit.currentHPImag *= thisWeapon.currentRealDmgModifier;
            } else {
                enemyUnit.currentHPReal /= thisWeapon.currentRealDmgModifier;
                enemyUnit.currentHPImag /= thisWeapon.currentRealDmgModifier;
            }
        } else {
            imaginaryMDCalc(enemyUnit);
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

    //TO-DO: For now, this function only handles pure imaginary damage, rather than imaginary and real damage
    private void imaginaryMDCalc(Unit enemyUnit) {
        //complex HP * imaginary attack
        if (!thisWeapon.damagingDown) {
                float temp = enemyUnit.currentHPImag;
                enemyUnit.currentHPImag = enemyUnit.currentHPReal * thisWeapon.currentImagDmgModifier;
                enemyUnit.currentHPReal = temp * thisWeapon.currentImagDmgModifier * -1; 
        } else { //complex HP / imaginary attack
                float compConj = -1 * thisWeapon.currentImagDmgModifier;
                float temp = enemyUnit.currentHPImag;
                enemyUnit.currentHPImag = enemyUnit.currentHPReal * thisWeapon.currentImagDmgModifier;
                enemyUnit.currentHPReal = temp * thisWeapon.currentImagDmgModifier * -1;
                enemyUnit.currentHPImag /= (compConj * thisWeapon.currentImagDmgModifier);
                enemyUnit.currentHPReal /= (compConj * thisWeapon.currentImagDmgModifier);
            }
    }
}
