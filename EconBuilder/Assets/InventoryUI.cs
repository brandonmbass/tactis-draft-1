using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {
    private GridLayoutGroup grid; 
    void Start()
    {
        
    }

    Inventory _inventory;
    public Inventory Inventory
    {
        set
        {
            _inventory = value;
            _inventory.UpdateEvent.AddListener((args) => {
                DrawIcons();
            });
            DrawIcons();
        }
    
    }

    public void DrawIcons()
    {
        grid = transform.FindChild("ItemGrid").GetComponent<GridLayoutGroup>();
        //TODO clear the list first
        foreach (var stack in _inventory)
        {
            var iconPath = stack.Item.InventoryIcon;
            var icon = Instantiate(Resources.Load<Image>("Icons/axe"));
            var t = icon.transform;
            var gt = grid.transform;
            t.SetParent(gt, false);
        }
    }

    internal void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}   
