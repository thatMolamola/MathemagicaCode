using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    public WeaponItem thisWeapon;

    public virtual void loadValues(){}

    //TO-DO Weapons should be able to affect enemy Unit HP in many ways more than addition and subtraction
    public virtual void Attack(Unit enemyUnit){}

    //Always allow the player to do one unit of health, real or not, in the direction the corresponding weapon works
    public virtual void MinAttack(Unit enemyUnit){
    }

}
