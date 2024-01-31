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
    public Image heartRender;
    private Sprite heartSprite1, heartSprite2, heartSprite3, heartSprite4;

    //To-do: implement HP initial HP with the imaginary component and visual representation

    public void Awake() {
        heartSprite1 = Resources.Load<Sprite>("Sprites/Heart_0");
        heartSprite2 = Resources.Load<Sprite>("Sprites/Heart_1");
        heartSprite3 = Resources.Load<Sprite>("Sprites/Heart_2");
        heartSprite4 = Resources.Load<Sprite>("Sprites/Heart_3");
    }

    public void SetHUD(Unit unit) {
        nameText.text = unit.unitName;
        hpSlider.maxValue = unit.initialHPReal;
        hpSlider.value = unit.currentHPReal;
        hpText.text = "HP: " + unit.currentHPReal;
        HPSliderAngle(unit);
        setHeartColor(unit);
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

    public void setHeartColor(Unit unit) {
        if (unit.currentHPReal >= 0 && unit.currentHPImag >= 0) {
            heartRender.sprite = heartSprite1;
        } else if (unit.currentHPReal < 0 && unit.currentHPImag >= 0) {
            heartRender.sprite = heartSprite2;
        } else if (unit.currentHPReal >= 0 && unit.currentHPImag < 0) {
            heartRender.sprite = heartSprite3;
        } else if (unit.currentHPReal < 0 && unit.currentHPImag >= 0) {
            heartRender.sprite = heartSprite4;
        }
    }

    public void setTop(Transform allyHUD) {
        allyHUD.SetAsFirstSibling();
        Debug.Log("click");
    }
}
