using System;
using System.Collections.Generic;
using System.Linq;

public class Interaction
{
    public string Name { get; set; }

    public virtual bool Apply(NPC npc, World world)
    {
        return true;
    }
}

public class DiseaseInteraction : Interaction
{
}

public class RomanceInteraction : Interaction
{
    public NPC Target { get; set; }

    public override bool Apply(NPC npc, World world)
    {
        var candidates = world.AllNPCs.Where(n => {
            return npc.Gender != n.Gender 
            && Math.Abs(npc.Age - n.Age) < 10 
            && npc.Age > 18 && n.Age > 18;
        });

        if (candidates.Count() == 0)
        {
            return false;
        }

        Target = candidates.ElementAt(DDRand.Int(0, candidates.Count() - 1));
        return true;
    }
}


static public class Interactions
{
    static public List<Interaction> AllInteractions { get; set; }
    static public void GenerateInteractions(List<NPC> npcs)
    {
        
    }

    static Interactions()
    {
        AllInteractions = new List<Interaction>();

        Interaction interaction = new DiseaseInteraction()
        {
            Name = "Pox",
        };
        AllInteractions.Add(interaction);

        interaction = new RomanceInteraction()
        {
            Name = "Unrequited Love",
        };
        AllInteractions.Add(interaction);
    }
}