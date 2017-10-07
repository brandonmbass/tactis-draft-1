using UnityEngine;

public class LumberjackData : MonoBehaviour
{
    public Store Store { get; set; }

    public LumberjackData()
    {
        Store = new Store();
        Store.AddItem(Items.WoodBow, 1);
        Store.AddItem(Items.WoodFishingPole, 1);
        Store.AddItem(Items.Knife, 1);
    }
}