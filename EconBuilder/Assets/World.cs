using System.Collections.Generic;

public class World
{
    public List<NPC> AllNPCs { get; set; }

    static public World Instance { get; set; }
    static public void CreateNew()
    {
        Instance = new World();
        Instance.AllNPCs = NPCs.GenerateNPCs();
        Traits.GenerateTraits(Instance.AllNPCs);
        Interactions.GenerateInteractions(Instance.AllNPCs);
    }
}