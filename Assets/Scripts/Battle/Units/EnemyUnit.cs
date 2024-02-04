using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUnit : Unit
{
    private bool flipped;

    public GameObject heartRender;
    private Image heartImage;
    public SpriteRenderer EnemySprite;
    public Sprite[] sprites;

    //Damage Variables
    public int standardDmg;
    public bool hasSecondStand;
    public int specialDmg;

    public float darkMultiplier;

    //Special Counter
    public int numTurnsToStandardTwo;
    public int numTurnsLeftStandardTwo;
    public int numTurnsToSpecial;
    public int numTurnsLeftSpecial;

    public GameObject unitPrefab;

    public void Start() {
        Image heartImage = heartRender.GetComponent<Image>();
        numTurnsLeftSpecial = numTurnsToSpecial;
        numTurnsLeftStandardTwo = numTurnsToStandardTwo;
        flipped = false;
    }

    public void animChange() {
        flipped = !flipped;
        gameObject.GetComponent<Animator>().SetBool("Flipped", flipped);
    }

    public void HealthFlip() {
        if (flipped) {
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
        if (flipped) {
            enemyUnit.currentHPReal -= standardDmg * darkMultiplier;
        }
        enemyUnit.currentHPReal -= standardDmg;
        numTurnsLeftSpecial -= 1;
        numTurnsLeftStandardTwo -= 1;
        return deathCheck(enemyUnit);
    }

    public string secondStandardAttack(Unit enemyUnit){
        numTurnsLeftStandardTwo = numTurnsToStandardTwo;
        if (unitName == "Wrathmetic") {
            float randValue1 = Random.value;
            float randHeal = Mathf.FloorToInt(100 * randValue1) / 100;
            enemyUnit.currentHPReal += randHeal;
            return "The Wrathmetic blurs its form!";
        } else if (unitName == "Door") {
            return "The door just sits there and takes it!";
        } else {
            return "";
        }
    }

    public bool specialAttack(Unit enemyUnit){
        specialDmgCalc(enemyUnit);
        numTurnsLeftSpecial = numTurnsToSpecial;
        return deathCheck(enemyUnit);
    }

    public void specialDmgCalc(Unit enemyUnit){
        float randValue1 = Random.value;
        float randValue2 = Random.value;
        if (unitName == "Triubble") {
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
        } else if (unitName == "Wrathmetic") {
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

