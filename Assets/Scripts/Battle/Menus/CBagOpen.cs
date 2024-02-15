using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBagOpen : MonoBehaviour
{
    [SerializeField] private GameObject bagObject, enchantObject;

    //if you enchant, open the bag screen
    public void onPressBagOpen(){
        bagObject.SetActive(true);
        enchantObject.SetActive(false);
    }

    //if you quit, close the bag screen
    public void onPressBagClose(){
        bagObject.SetActive(false);
        enchantObject.SetActive(true);
    }
}
