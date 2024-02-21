using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorWeapon : Weapon
{
    public override void Attack (Unit enemyUnit){
        enemyUnit.thisUnit.currentHPReal = Mathf.Floor(enemyUnit.thisUnit.currentHPReal);
        enemyUnit.thisUnit.currentHPImag = Mathf.Floor(enemyUnit.thisUnit.currentHPImag);
    }
}
