using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This PlayerUnit Class handles the Actions that are handed to it by the BattleSystem, and 
// returns the appropriate ActionResponse for the BattleSystem to handle.
public class PlayerUnit : Unit
{
    [SerializeField] private Weapon[] weaponList;
    private bool fledSuccess;
    private NPItem chosenItem;
    private ActionResponse reply;

    //executeAction takes an action, and returns an actionResponse after executing said action
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

    //selectedWeaponAttack calls the weapon's attack onto the target
    //Issues: Only handles exclusively real or imaginary damage, rather than both
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

    //selectedEnchant changes the weapon's damage output
    //Issues: Only handles changes to the real dmg modifiers for now
    private string selectedEnchant(Weapon weapon){
        weapon.thisWeapon.currentRealDmgModifier = chosenItem.NPValue;
        weapon.thisWeapon.modded = true;
        weapon.thisWeapon.ModDurationLeft = weapon.thisWeapon.MaxModDuration;
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

    //TO-DO: Implement Flee Checks in some way that makes sense
    private bool fleeCheck(Unit enemyUnit){
        return true;
    }

    //checks whether the enemy has died. Currently has partial implemenetation for the sprite flipping, but this should be relocated
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
