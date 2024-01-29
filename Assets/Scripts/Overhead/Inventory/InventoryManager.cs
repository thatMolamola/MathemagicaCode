using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ItemClass> items = new List<ItemClass>();

    public void Start() {

    }

    public void Add(ItemClass item) {
        items.Add(item);
    }

    public void Remove(ItemClass item) {
        items.Remove(item);
    }

}
