﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    Truncon.Collections.OrderedDictionary<System.Type, Items.ItemStack> _contents;

    public void Store(Items.Item item, int count = 1)
    {
        var itemType = item.GetType();
        if (_contents.ContainsKey(itemType))
        {
            _contents[itemType].Count += count;
        }
         else
        {
            _contents.Add(itemType, new Items.ItemStack(item, count));
        }
    }

    public void Store(Items.ItemStack addedStack)
    {
        var itemType = addedStack.Item.GetType();
        if (_contents.ContainsKey(itemType))
        {
            var itemStack = _contents[itemType].Count += addedStack.Count; ;
        } 
        else
        {
            _contents.Add(itemType, addedStack);
        }
    }

    public int Count(System.Type itemType)
    {
        if (_contents.ContainsKey(itemType))
        {
            return _contents[itemType].Count;
        }
        return 0;
    }

    public int Remove(System.Type itemType, int quantity)
    {
        if (!_contents.ContainsKey(itemType))
        { 
            return 0;
        }

        var removed = 0;
        var count = Count(itemType);
        if (count > quantity)
        {
            _contents[itemType].Count -= quantity;
            removed = quantity;
        }
        else
        {
            removed = count;
            _contents.Remove(itemType);
        }
        return removed;
    }

    public Items.ItemStack RetrieveAll(System.Type itemType)
    {
        if (!_contents.ContainsKey(itemType))
        {
            return null;
        }

        var itemStack = _contents[itemType];
        _contents.Remove(itemType);
        return itemStack;
    }

    public Items.ItemStack Retrieve(System.Type itemType, int quantity)
    {
        if (!_contents.ContainsKey(itemType))
        {
            return null;
        }

        var item = _contents[itemType].Item;
        var removed = Remove(itemType, quantity);

        return new Items.ItemStack(item, removed);
    }

    public Items.ItemStack RetrieveAllAt(int index) {
        var key = _contents.GetKey(index);
        return RetrieveAll(key);
    }

    public Items.ItemStack RetrieveAt(int index, int quantity)
    {
        var key = _contents.GetKey(index);
        return Retrieve(key, quantity);
    }

    public void GiveAll(Inventory other)
    {
        foreach(var content in _contents)
        {
            other.Store(content.Value);
        }
        _contents.Clear();
    }

    public void TakeAll(Inventory other)
    {
        other.GiveAll(this);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
