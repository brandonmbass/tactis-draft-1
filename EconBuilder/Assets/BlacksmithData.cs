using UnityEngine;

public class BlacksmithData : MonoBehaviour
{
    public Store Store { get; set; }

    public BlacksmithData()
    {
        Store = new Store();
        Store.AddItem(Items.WoodBow, 1);
        Store.AddItem(Items.WoodFishingPole, 1);
        Store.AddItem(Items.Knife, 1);
    }
}
