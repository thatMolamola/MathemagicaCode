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
        baseDmgModifier = 5;
        damagingDown = false; 
        real = true;
    }

    public override void Attack (Unit enemyUnit){
        if (real) {
            if (!damagingDown) {
                enemyUnit.currentHPReal *= currentDmgModifier;
            } else {
                enemyUnit.currentHPReal /= currentDmgModifier;
            }
        } else {
            if (!damagingDown) {
                enemyUnit.currentHPImag *= currentDmgModifier;
            } else {
                enemyUnit.currentHPImag /= currentDmgModifier;
            }
        }

        if (!permMod) {
            if (modded) {
                ModDurationLeft -= 1; 
                if (ModDurationLeft == 0) {
                    currentDmgModifier = baseDmgModifier;
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
