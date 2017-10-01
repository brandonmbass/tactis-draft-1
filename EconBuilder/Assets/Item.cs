// Represents any item. Can go on the ground, takes up inventory slot, etc
// Note, this doesn't include resources (gold, wood, etc)

namespace Items
{
    abstract public class Item
    {
        public Item(int stackCount, string inventoryIcon, int goldValue)
        {
            Name = this.GetType().Name;
            StackCount = stackCount;
            InventoryIcon = inventoryIcon;
            GoldValue = goldValue;
        }

        public string Name { get; set; }
        public int StackCount { get; set; }
        public string InventoryIcon { get; set; }
        public int GoldValue { get; set; }        
    }

    abstract public class FishingPole : Item
    {
        public FishingPole(string inventoryIcon, int goldValue) : base(1, inventoryIcon, goldValue)
        {
        }
    }

    public class WoodenFishingPole : FishingPole
    {
        public WoodenFishingPole() : base("TODO", 10) { }
    }

    public class CopperFishingPole : FishingPole
    {
        public CopperFishingPole() : base("TODO", 50) { }
    }


    public class ItemStack
    {
        public Item Item { get; set; }
        public int Count { get; set; }

        public ItemStack(Item item, int count)
        {
            Item = item;
            Count = count;
        }
    }

}