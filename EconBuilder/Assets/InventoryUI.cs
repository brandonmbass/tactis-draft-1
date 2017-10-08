using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    public Inventory inventory;
    public GameObject list;
    GameObject prefabInventoryItem = Resources.Load("Prefabs/InventoryItem") as GameObject;

    public InventoryUI(Inventory inv)
    {
        inventory = inv;
        foreach(var stack in inventory)
        {
            var item = Instantiate(prefabInventoryItem);
            item.transform.SetParent(list.transform);
        }
    }
}   
