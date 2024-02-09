using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] private Text nameText; 
    [SerializeField] private Text hpText; 
    [SerializeField] private Transform hpSContain;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Image heartRender;
    private Sprite heartSprite1, heartSprite2, heartSprite3, heartSprite4;

    private void Awake() {
        heartSprite1 = Resources.Load<Sprite>("Sprites/Heart_0");
        heartSprite2 = Resources.Load<Sprite>("Sprites/Heart_1");
        heartSprite3 = Resources.Load<Sprite>("Sprites/Heart_2");
        heartSprite4 = Resources.Load<Sprite>("Sprites/Heart_3");
    }

    public void SetHUD(Unit unit) {
        nameText.text = unit.unitName;
        if (unit.currentHPImag == 0) {
            hpSlider.maxValue = unit.initialHPReal;
            hpSlider.value = unit.currentHPReal;
            hpText.text = "HP: " + unit.currentHPReal;
        } else {
            hpSlider.maxValue = Mathf.Sqrt(Mathf.Pow(unit.initialHPReal, 2) + Mathf.Pow(unit.initialHPImag, 2));
            hpSlider.value = Mathf.Sqrt(Mathf.Pow(unit.currentHPReal, 2) + Mathf.Pow(unit.currentHPImag, 2));
            hpText.text = "HP: " + unit.currentHPReal + " + " + unit.currentHPImag + "i";
        }

        HPSliderAngle(unit);
        setHeartColor(unit);
    }

    private void HPSliderAngle(Unit unit) {
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

    private void setHeartColor(Unit unit) {
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
    }
}
