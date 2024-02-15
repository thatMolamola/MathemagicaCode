using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "UnitData", menuName = "Data Storage/Unit Data")]
public class UnitData : ScriptableObject
{
    //General Unit Data
    public string unitName;

    //HP Stats
    public float currentHPReal; 
    public float currentHPImag; 
    public float initialHPReal;
    public float initialHPImag;

    //Aura Bools
    public bool withImaginary;
    public bool negative;
}
