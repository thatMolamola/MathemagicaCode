using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorWeapon : Weapon
{
    public void Start () {
        //set Weapon Specific Constants
        //Modable conditions
        modable = false;

        //Weapon Attack Variety
        baseDmgModifier = 0;
        damagingDown = false; 
        real = true;
    }

    public override void Attack (Unit enemyUnit){
        enemyUnit.currentHPReal = Mathf.Floor(enemyUnit.currentHPReal);
        enemyUnit.currentHPImag = Mathf.Floor(enemyUnit.currentHPImag);
    }
}
