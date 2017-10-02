using System;

static public class Items
{
    static public UsableItemType Lathe = new UsableItemType("Lathe", 1, "TODO", 100);
    static public UsableItemType Furnace = new UsableItemType("Furnace", 1, "TODO", 200);
    static public UsableItemType Anvil = new UsableItemType("Anvil", 1, "TODO", 200);
    static public ItemType Feather = new ItemType("Feather", 200, "TODO", 1);
    static public ItemType Linen = new ItemType("Linen", 100, "TODO", 1);
    static public ItemType IronOre = new ItemType("IronOre", 20, "TODO", 1);
    static public ItemType IronIngot = new ItemType("IronIngot", 50, "TODO", 1);
    static public ItemType Log = new ItemType("Log", 100, "TODO", 1);
    static public ItemType WoodPlank = new ItemType("Wood plank", 100, "TODO", 1);
    static public ItemType ArrowHead = new ItemType("Arrowhead", 100, "TODO", 5);
    static public ItemType Arrow = new ItemType("Arrow", 100, "TODO", 10);

    // Bows
    static public ItemType WoodBow = new Bow("Wooden bow", "TODO", 40);

    // Fishing poles
    static public ItemType WoodFishingPole = new FishingPole("Wooden fishing pole", "TODO", 10);
    static public ItemType CopperFishingPole = new FishingPole("Copper fishing pole", "TODO", 50);

    // Melee weapons
    static public UsableItemType Knife = new UsableItemType("Knife", 10, "TODO", 20);

    // etc.
}

public interface IUsable
{
    bool InUse { get; set; }
}

public class ItemType
{
    public ItemType(string name, int stackCount, string inventoryIcon, int goldValue)
    {
        Name = name;
        StackCount = stackCount;
        InventoryIcon = inventoryIcon;
        GoldValue = goldValue;
    }

    public string Name { get; set; }
    public int StackCount { get; set; }
    public string InventoryIcon { get; set; }
    public int GoldValue { get; set; }        
}

public class UsableItemType : ItemType, IUsable
{
    // TODO: maybe every item should be usable?
    public bool InUse { get; set; }

    public UsableItemType(string name, int stackCount, string inventoryIcon, int goldValue) : base(name, stackCount, inventoryIcon, goldValue)
    {
    }
}

public class FishingPole : ItemType
{
    public FishingPole(string name, string inventoryIcon, int goldValue) : base(name, 1, inventoryIcon, goldValue)
    {
    }
}

public class Bow : ItemType
{
    public Bow(string name, string inventoryIcon, int goldValue) : base(name, 1, inventoryIcon, goldValue)
    {
    }
}

public class ItemStack
{
    public ItemType Item { get; set; }
    public int Count { get; set; }

    public ItemStack(ItemType item, int count)
    {
        Item = item;
        Count = count;
    }
}

