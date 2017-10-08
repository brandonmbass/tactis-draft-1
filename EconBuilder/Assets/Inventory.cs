using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    Truncon.Collections.OrderedDictionary<ItemType, ItemStack> _contents;

    public void Store(ItemType itemType, int count = 1)
    {
        if (_contents.ContainsKey(itemType))
        {
            _contents[itemType].Count += count;
        }
         else
        {
            _contents.Add(itemType, new ItemStack(itemType, count));
        }
    }

    public void Store(ItemStack addedStack)
    {
        var itemType = addedStack.Item;
        if (_contents.ContainsKey(itemType))
        {
            var itemStack = _contents[itemType].Count += addedStack.Count; ;
        } 
        else
        {
            _contents.Add(itemType, addedStack);
        }
    }

    public int Count(ItemType itemType)
    {
        if (_contents.ContainsKey(itemType))
        {
            return _contents[itemType].Count;
        }
        return 0;
    }

    public int Remove(ItemType itemType, int quantity)
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

    public ItemStack RetrieveAll(ItemType itemType)
    {
        if (!_contents.ContainsKey(itemType))
        {
            return null;
        }

        var itemStack = _contents[itemType];
        _contents.Remove(itemType);
        return itemStack;
    }

    public ItemStack Retrieve(ItemType itemType, int quantity)
    {
        if (!_contents.ContainsKey(itemType))
        {
            return null;
        }

        var removed = Remove(itemType, quantity);

        return new ItemStack(itemType, removed);
    }

    public ItemStack RetrieveAllAt(int index) {
        var key = _contents.GetKey(index);
        return RetrieveAll(key);
    }

    public ItemStack RetrieveAt(int index, int quantity)
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

    public int Count()
    {
        return _contents.Count;
    }

    public IEnumerator<ItemStack> GetEnumerator()
    {
        var itr = _contents.GetEnumerator();
        foreach(var pair in _contents)
        {
            yield return pair.Value;
        }
    }

    public ItemStack this[int i]
    {
        get { return _contents[i];  }
        set { _contents[i] = value; }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
