using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Health: MonoBehaviour {
 
    public float realZeroX = 10;
    public float imaginaryZeroX = 0;
    public float oneX = 0;

    public bool hasVariable = false;

    public string fullExpression = "";

    public Text t;

    public Health varSub = null;

 
    public void Start() {
        if (oneX != 0) {
            hasVariable = true;
        }
    }

    public void Update() {
        displayExpression();
    }

    public void displayExpression() {
        if (oneX == 0.0f){
            if (imaginaryZeroX == 0.0f){
                fullExpression = System.String.Format("{0}", realZeroX);
            } else{
                fullExpression = System.String.Format("{0} + {1}i", realZeroX, imaginaryZeroX);
            }
            
        } else {
            fullExpression = System.String.Format("{0}x + {1} + {2}i", oneX, realZeroX, imaginaryZeroX);
        }
    }

    //is this even being used? I don't think so
    public void Copy(Health subExpression) {
        this.realZeroX = subExpression.realZeroX;
        this.imaginaryZeroX = subExpression.imaginaryZeroX;
        this.oneX = subExpression.oneX;
        this.hasVariable = subExpression.hasVariable;
        this.fullExpression = subExpression.fullExpression;
        this.varSub = subExpression.varSub;
    }
}
