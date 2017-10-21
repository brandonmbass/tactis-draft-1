using System;
using System.Collections;
using System.Collections.Generic;
using Truncon.Collections;
using UnityEngine;

public class Inventory : MonoBehaviour {
    OrderedDictionary<ItemType, ItemStack> _contents = new OrderedDictionary<ItemType, ItemStack>();
    OrderedDictionary<ResourceType, int> _resources = new OrderedDictionary<ResourceType, int>();

    public EconEvent UpdateEvent { get; set; }

    public void Start()
    {
        UpdateEvent = new EconEvent();
        foreach (var resource in Enum.GetValues(typeof(ResourceType)))
        {
            _resources[(ResourceType)resource] = 0;
        }
    }

    public void Add(int count, ItemType itemType)
    {
        if (_contents.ContainsKey(itemType))
        {
            _contents[itemType].Count += count;
        }
         else
        {
            _contents.Add(itemType, new ItemStack(itemType, count));
        }
        UpdateEvent.Invoke();
    }

    public void Add(int count, ResourceType resourceType)
    {
        _resources[resourceType] += count;
    }

    public void Add(ItemStack addedStack)
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
        UpdateEvent.Invoke();
    }

    public int Count(ItemType itemType)
    {
        if (_contents.ContainsKey(itemType))
        {
            return _contents[itemType].Count;
        }
        return 0;
    }

    public int Count(ResourceType resourceType)
    {
        return _resources[resourceType];
    }

    public bool Has(int count, ItemType itemType)
    {
        return Count(itemType) >= count;
    }

    public bool Has(int count, ResourceType resourceType)
    {
        return Count(resourceType) >= count;
    }

    public int Remove(int quantity, ItemType itemType)
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

        UpdateEvent.Invoke();
        return removed;
    }

    public ItemStack TakeAll(ItemType itemType)
    {
        if (!_contents.ContainsKey(itemType))
        {
            return null;
        }

        var itemStack = _contents[itemType];
        _contents.Remove(itemType);

        UpdateEvent.Invoke();
        return itemStack;
    }

    public ItemStack Take(int quantity, ItemType itemType)
    {
        if (!_contents.ContainsKey(itemType))
        {
            return null;
        }

        var removed = Remove(quantity, itemType);

        UpdateEvent.Invoke();
        return new ItemStack(itemType, removed);
    }

    public void GiveAll(Inventory other)
    {
        foreach(var content in _contents)
        {
            other.Add(content.Value);
        }
        _contents.Clear();
        UpdateEvent.Invoke();
    }

    public void TakeAll(Inventory other)
    {
        other.GiveAll(this);
        UpdateEvent.Invoke();
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

}
