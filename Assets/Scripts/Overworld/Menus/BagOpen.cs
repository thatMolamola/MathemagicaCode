using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagOpen : MonoBehaviour
{
    [SerializeField] private GameObject bagObject, enchantObject;

    public void onPressBagOpen(){
        bagObject.SetActive(true);
        enchantObject.SetActive(false);
    }

    public void onPressBagClose(){
        bagObject.SetActive(false);
        enchantObject.SetActive(true);
    }
}
