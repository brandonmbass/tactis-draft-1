using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Recipe
{
    public ItemType Result { get; set; }
    public List<ItemStack> Materials { get; set; }
    public List<IUsable> Requirements { get; set; }
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
}

static public class Recipes
{    
    static public List<Recipe> RecipeList { get; set; }

    static Recipes()
    {
        RecipeList = new List<Recipe>();

        AddRecipe(Items.WoodPlank)
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

        AddRecipe(Items.Arrow)
            .AddMaterial(Items.ArrowHead, 1)
            .AddMaterial(Items.WoodPlank, 1)
            .AddMaterial(Items.Feather, 2)
            .Requires(Items.Knife);
    }

    static private Recipe AddRecipe(ItemType result, bool known = true)
    {
        var recipe = new Recipe(result);
        recipe.Known = known;
        RecipeList.Add(recipe);
        return recipe;
    }
}
 

public class Attribute
{

}

public class NearForge
{

}