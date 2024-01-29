using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {
    public bool canEvaluate;

    public void start() {
        canEvaluate = false;
    }

    public void Update() {
        base.Update();
        if (!hasVariable) {
            if ((realZeroX == 0.0f) && (imaginaryZeroX == 0.0f) && (oneX == 0.0f)) {
                Destroy(gameObject);
            }
        } else {
            if ((realZeroX == 0.0f) && (imaginaryZeroX == 0.0f) && (oneX == 1.0f)) {
                canEvaluate = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        //Debug.Log("Hello: " + gameObject.name);
        if(other.CompareTag("Weapon")){
            //SubtractEnemyHealth(20);    // note that playerHealth and damageAmount are already set in the parent class!
        }
    }

    public void floorHealth() {
        realZeroX = Mathf.Floor(realZeroX);
        imaginaryZeroX = Mathf.Floor(imaginaryZeroX);
        oneX = Mathf.Floor(oneX);
    }
}
