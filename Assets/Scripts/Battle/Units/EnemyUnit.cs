using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUnit : Unit
{
    private int enemyID;

    public GameObject heartRender;
    private Image heartImage;
    public SpriteRenderer EnemySprite;
    public Sprite[] sprites;

    //Weapon Variables
    public int standardDmg;
    public int specialDmg;

    public float darkMultiplier;

    //Special Counter
    public int numTurnsToSpecial;
    public int numTurnsLeft;

    public void Start() {
        Image heartImage = heartRender.GetComponent<Image>();
        numTurnsLeft = numTurnsToSpecial;
    }

    public void HealthFlip() {
        if (negative) {
            heartImage.sprite = sprites[2];
        } else {
            heartImage.sprite = sprites[1];
        }
    }

    public override bool deathCheck(Unit enemyUnit) {
        if (enemyUnit.currentHPReal <= 0 && enemyUnit.currentHPImag == 0) {
            return true;
        } else {return false;}
    
    }

    public bool standardAttack(Unit enemyUnit){
        enemyUnit.currentHPReal -= standardDmg;
        numTurnsLeft -= 1;
        return deathCheck(enemyUnit);
    }

    public bool specialAttack(Unit enemyUnit){
        specialDmgCalc(enemyUnit);
        numTurnsLeft = numTurnsToSpecial;
        return deathCheck(enemyUnit);
    }

    public void specialDmgCalc(Unit enemyUnit){
        float randValue1 = Random.value;
        float randValue2 = Random.value;
        if (enemyID == 1) {
            if (randValue1 < .037037) {
                enemyUnit.currentHPReal -= 15;
                return;
            } else if (randValue1 < .111111) {
                enemyUnit.currentHPReal -= 12;
                return;
            } else { 
                enemyUnit.currentHPReal -= 9;
                return;
                }
        } else if (enemyID == 2) {
            float randDamage = Mathf.FloorToInt(100 * randValue2) / 100;
            if (randValue1 < .25) {
                enemyUnit.currentHPReal -= randDamage;
                return;
            } else if (randValue1 < .5) {
                enemyUnit.currentHPReal += randDamage;
                return;
            } else if (randValue1 < .75) {
                enemyUnit.currentHPReal /= randDamage;
                return;
            } else { 
                enemyUnit.currentHPReal *= randDamage;
                return;
            }
        } else {
            enemyUnit.currentHPReal -= 10;
        }
    }
}

