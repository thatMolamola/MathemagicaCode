using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText; 
    public Text hpText; 
    public Transform hpSContain;
    public Slider hpSlider;

    //To-do: implement HP initial HP with the imaginary component and visual representation
    public void SetHUD(Unit unit) {
        nameText.text = unit.unitName;
        hpSlider.maxValue = unit.initialHPReal;
        hpSlider.value = unit.currentHPReal;
        hpText.text = "HP: " + unit.currentHPReal;
    }

    public void SetHP (float hp) {
        hpSlider.value = hp;
        hpText.text = "HP: " + hp;
    }

    public void HPSliderAngle(Unit unit) {
        if (unit.currentHPImag == 0 && unit.currentHPReal == 0) {
            return;
        }
        float angle = 0f;
        if (unit.currentHPReal < 0) {
            angle = 180 - (Mathf.Atan(unit.currentHPImag / -unit.currentHPReal) * 180 / Mathf.PI);
        } else {
            angle = (Mathf.Atan(unit.currentHPImag / unit.currentHPReal) * 180 / Mathf.PI);
        }
        hpSContain.transform.eulerAngles = new Vector3(0,0,angle);
    }
}
