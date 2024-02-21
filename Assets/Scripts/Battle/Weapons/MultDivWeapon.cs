using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultDivWeapon : Weapon
{
    public override void Attack (Unit enemyUnit){
        if (thisWeapon.real) {
            realMDCalc(enemyUnit);
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


    //TO-DO: this function checks whether the attack value is zero, but does not handle those cases yet
    private void realMDCalc(Unit enemyUnit) {
        //complex HP * real attack
        if (thisWeapon.currentRealDmgModifier != 0) {
            if (!thisWeapon.damagingDown) {
                enemyUnit.thisUnit.currentHPReal *= thisWeapon.currentRealDmgModifier;
                enemyUnit.thisUnit.currentHPImag *= thisWeapon.currentRealDmgModifier;
            } else {
                enemyUnit.thisUnit.currentHPReal /= thisWeapon.currentRealDmgModifier;
                enemyUnit.thisUnit.currentHPImag /= thisWeapon.currentRealDmgModifier;
            }
        } else {
            //Figure out what to do if multiplying or dividing by 0.
        }
    }

    //TO-DO: For now, this function only handles pure imaginary damage, rather than imaginary and real damage
    private void imaginaryMDCalc(Unit enemyUnit) {
        //complex HP * imaginary attack
        if (thisWeapon.currentImagDmgModifier != 0) {
            if (!thisWeapon.damagingDown) {
                float temp = enemyUnit.thisUnit.currentHPImag;
                enemyUnit.thisUnit.currentHPImag = enemyUnit.thisUnit.currentHPReal * thisWeapon.currentImagDmgModifier;
                enemyUnit.thisUnit.currentHPReal = temp * thisWeapon.currentImagDmgModifier * -1; 
            } else { //complex HP / imaginary attack
                float compConj = -1 * thisWeapon.currentImagDmgModifier;
                float temp = enemyUnit.thisUnit.currentHPImag;
                enemyUnit.thisUnit.currentHPImag = enemyUnit.thisUnit.currentHPReal * thisWeapon.currentImagDmgModifier;
                enemyUnit.thisUnit.currentHPReal = temp * thisWeapon.currentImagDmgModifier * -1;
                enemyUnit.thisUnit.currentHPImag /= (compConj * thisWeapon.currentImagDmgModifier);
                enemyUnit.thisUnit.currentHPReal /= (compConj * thisWeapon.currentImagDmgModifier);
            }
        } else {
            //Figure out what to do if multiplying or dividing by 0.
        }
    }
}
