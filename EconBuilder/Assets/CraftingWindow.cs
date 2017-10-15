using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingWindow : EconBehavior {
    private List<Recipe> recipes = new List<Recipe>();
    private Recipe selected;
    public void Init()
    {
        if (recipes.Count > 0)
        {
            return;
        }

        var createButton = this.gameObject.transform.Find("CraftingPanel/CreateButton");
        createButton.GetComponent<Button>().onClick.AddListener(CreateItem);

        AddCraftingItem(Recipes.GetRecipe(Items.WoodPlank));
        AddCraftingItem(Recipes.GetRecipe(Items.Arrow));
    }

    public void AddCraftingItem(Recipe recipe)
    {        
        var list = this.gameObject.transform.Find("LeftPanel/CraftingList/Viewport/Content");
        var recipeGO = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/CraftingListItem"), list);
        recipeGO.transform.Find("Text").GetComponent<Text>().text = recipe.Result.Name;
        recipeGO.transform.localPosition = new Vector3(0, recipes.Count * -90, 0);        
        
        recipeGO.GetComponent<EconSelectable>().SelectEvent.AddListener((args) =>
        {
            var currentText = this.gameObject.transform.Find("CraftingPanel/ResultPanel/Name").GetComponent<Text>();
            currentText.text = recipe.Result.Name;
            selected = recipe;
        });

        recipes.Add(recipe);
    }

    public void CreateItem()
    {
        if (selected == null)
        {
            Debug.Log("Nothing selected");
            return;
        }

        if (!selected.CanMake())
        {
            Debug.Log("Can't make");
            return;
        }

        selected.Craft();
        Debug.Log("Success! Made: " + selected.Result.Name);
    }
}
