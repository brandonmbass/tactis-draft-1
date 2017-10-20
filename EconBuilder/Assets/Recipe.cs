using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Recipe
{
    // TODO: Should Result + ResultCount just be one ItemStack? Or, should we get rid of ItemStack class?
    public ItemType Result { get; set; }
    public List<ItemStack> Materials { get; set; }
    public List<IUsable> Requirements { get; set; }
    public int ResultCount { get; set; }
    public bool Known { get; set; }

    public Recipe(ItemType result)
    {
        Result = result;
        Materials = new List<ItemStack>();
        Requirements = new List<IUsable>();
    }

    public Recipe AddMaterial(ItemType item, int count)
    {
        Materials.Add(new ItemStack(item, count));
        return this;
    }

    public Recipe Requires(IUsable usable)
    {
        Requirements.Add(usable);
        return this;
    }

    public bool CanMake()
    {
        // TODO: should this be on character?
        foreach (var material in Materials)
        {
            if (!G.CurrentCharacter.Inventory.Has(material.Count, material.Item))
            {
                return false;
            }
        }

        // TODO: Requires check

        return true;
    }

    public void Craft()
    {
        foreach (var material in Materials)
        {
            G.CurrentCharacter.Inventory.Take(material.Count, material.Item);
        }

        G.CurrentCharacter.Inventory.Add(this.ResultCount, this.Result);
    }
}

static public class Recipes
{    
    static public List<Recipe> RecipeList { get; set; }

    static Recipes()
    {
        RecipeList = new List<Recipe>();

        AddRecipe(Items.WoodPlank, 5)
            .AddMaterial(Items.Log, 1);

        AddRecipe(Items.WoodBow)
            .AddMaterial(Items.WoodPlank, 2)
            .AddMaterial(Items.Linen, 1)
            .Requires(Items.Lathe);

        AddRecipe(Items.IronIngot)
            .AddMaterial(Items.IronOre, 1)
            .Requires(Items.Furnace);

        AddRecipe(Items.ArrowHead)
            .AddMaterial(Items.IronIngot, 1)
            .Requires(Items.Anvil);

        // TODO: revert
        AddRecipe(Items.Arrow, 2)
            //.AddMaterial(Items.ArrowHead, 1)
            .AddMaterial(Items.WoodPlank, 1);
            //.AddMaterial(Items.Feather, 2)
            //.Requires(Items.Knife);
    }

    static private Recipe AddRecipe(ItemType result, int resultCount = 1, bool known = true)
    {
        var recipe = new Recipe(result);
        recipe.ResultCount = resultCount;
        recipe.Known = known;
        RecipeList.Add(recipe);
        return recipe;
    }

    static public Recipe GetRecipe(ItemType itemType)
    {
        // TODO: dictionary
        return RecipeList.Find(r => r.Result == itemType);
    }
}
 

public class Attribute
{

}

public class NearForge
{

}