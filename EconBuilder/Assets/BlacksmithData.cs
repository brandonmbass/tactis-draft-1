using Items;
using UnityEngine;

public class BlacksmithData : MonoBehaviour
{
    public Store Store { get; set; }

    public BlacksmithData()
    {
        Store = new Store();
        Store.AddItem(new WoodenFishingPole(), 1);
        Store.AddItem(new CopperFishingPole(), 1);
    }
}
