using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    [SerializeField] private Weapon[] weaponList;
    private bool fledSuccess;
    private NPItem chosenItem;
    private ActionResponse reply;

    public ActionResponse executeAction(Action selectAction) { 
        string action = selectAction.getAction();
        if (action == "ATTACK") {
            string buffer = selectedWeaponAttack(selectAction.getWeapon(), selectAction.getTarget());
            reply = new ActionResponse(selectAction, 0f, buffer, deathCheck(selectAction.getTarget()));
        } else if (action == "ENCHANT") {
            reply = new ActionResponse(selectAction, 0f, selectedEnchant(selectAction.getWeapon()), true);
        } else if (action == "FLEE") {
            reply = new ActionResponse(selectAction, 0f, selectedFlee(selectAction.getTarget()), fledSuccess);
        }
        return reply;
    }



    private string selectedWeaponAttack(Weapon weapon, Unit enemyUnit){
        float oldRealHP = enemyUnit.currentHPReal;
        float oldImagHP = enemyUnit.currentHPImag;
        weapon.Attack(enemyUnit);
        float rDamageDone = oldRealHP - enemyUnit.currentHPReal;
        float iDamageDone = oldImagHP - enemyUnit.currentHPImag;
        if (rDamageDone != 0) {
            return enemyUnit.unitName + " took " + damageRound(rDamageDone) + " damage from " + unitName + "!";
        } else {
            return enemyUnit.unitName + " took " + damageRound(iDamageDone) + "i damage from " + unitName + "!";
        }
    }

    private string selectedEnchant(Weapon weapon){
        weapon.thisWeapon.currentRealDmgModifier = chosenItem.NPValue;
        weapon.thisWeapon.modded = true;
        return unitName + "'s spell " +  weapon.thisWeapon.weaponName + " has been enchanted by " + chosenItem.itemName;
    }

    private string selectedFlee(Unit enemyUnit){
        fledSuccess = fleeCheck(enemyUnit);
        if (fledSuccess) {
            return unitName + " successfully ran from battle!";
        } else {
            return unitName + " attempted to flee, but failed!";
        }
    }

    private bool fleeCheck(Unit enemyUnit){
        return true;
    }

    private bool deathCheck(Unit enemyUnit) {
        if (enemyUnit.currentHPReal == 0 && enemyUnit.currentHPImag == 0) {
            return true;
        } else if (currentHPReal < 0 && enemyUnit.currentHPImag == 0){
            negative = true;
            return false;
        } else if (currentHPReal > 0 && enemyUnit.currentHPImag == 0){
            negative = false;
            return false;
        } else {
            return false;
        }
    }

    private float damageRound(float x) {
        return (Mathf.Round(x*1000)/1000);
    }

    public void setItem(NPItem item) {
        chosenItem = item;
    }

    public Weapon[] getWeaponList() {
        return weaponList;
    }
}
