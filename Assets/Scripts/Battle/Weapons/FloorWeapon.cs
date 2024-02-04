using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorWeapon : Weapon
{
    public override void Attack (Unit enemyUnit){
        enemyUnit.currentHPReal = Mathf.Floor(enemyUnit.currentHPReal);
        enemyUnit.currentHPImag = Mathf.Floor(enemyUnit.currentHPImag);
    }
}
