using System.Collections.Generic;

public class Store
{
    public List<ItemStack> Items { get; set; }

    public void AddItem(ItemType item, int count)
    {
        Items.Add(new ItemStack(item, count));
    }

    public Store()
    {
        Items = new List<ItemStack>();
    }
}
