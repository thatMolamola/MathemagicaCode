using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultDivWeapon : Weapon
{
    public void Start () {
        //set Weapon Specific Constants
        //Modable conditions
        permMod = false;
        MaxModDuration = 5; 
        modable = true;

        //Weapon Attack Variety
        baseRealDmgModifier = 5;
        damagingDown = false; 
        real = true;
    }

    public override void Attack (Unit enemyUnit){
        if (real) {
            if (!damagingDown) {
                enemyUnit.currentHPReal *= currentRealDmgModifier;
            } else {
                enemyUnit.currentHPReal /= currentRealDmgModifier;
            }
        } else {
            if (!damagingDown) {
                enemyUnit.currentHPImag *= currentRealDmgModifier;
            } else {
                enemyUnit.currentHPImag /= currentRealDmgModifier;
            }
        }

        if (!permMod) {
            if (modded) {
                ModDurationLeft -= 1; 
                if (ModDurationLeft == 0) {
                    currentRealDmgModifier = baseRealDmgModifier;
                    ModDurationLeft = MaxModDuration;
                    modded = false;
                }
            }
        }
    }

    public override void MinAttack (Unit enemyUnit){
        enemyUnit.currentHPReal += 1;
        return;
    }
}
