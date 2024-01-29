using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health {
    public GameObject t2;

    public void Update() {
        base.Update();
        if (realZeroX == 0) {
            t2.SetActive(true);
        }
    } 

    public void SubtractPlayerHealth(float damage){
        realZeroX = realZeroX - damage;
    }
}