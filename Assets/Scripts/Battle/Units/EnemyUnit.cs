using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUnit : Unit
{
    public GameObject heartRender;
    private Image heartImage;
    public SpriteRenderer EnemySprite;
    public Sprite[] sprites;

    //Weapon Variables
    public int standardDmg;
    public int specialDmg;

    public float darkMultiplier;

    public void Start() {
        Image heartImage = heartRender.GetComponent<Image>();
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

    public bool attackNoWeapon(Unit enemyUnit){
        enemyUnit.currentHPReal -= standardDmg;
        return deathCheck(enemyUnit);
    }
}
