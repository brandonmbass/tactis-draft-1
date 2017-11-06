using System;
using System.Collections.Generic;

public enum Gender
{
    Male,
    Female
}

public class ReligiousStatus
{
    public Religion Religion { get; set; }
    public float Devotion { get; set; }
}

public class NPC
{
    public string Name { get; set; }    
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public ReligiousStatus Religion { get; set; }
    public List<Skill> Skills { get; set; }
    public List<SkillType> Roles { get; set; }
    public List<Trait> Traits { get; set; }    
    public List<Interaction> Interactions { get; set; }
}

static public class NPCs
{
    static private Random rnd = new Random();
    static NPCs()
    {
        GenerateNPCs();
    }

    public static List<NPC> GenerateNPCs()
    { 
        var npcs = new List<NPC>();

        var npc = new NPC()
        {
            Name = "Gedrick",
            Age = GenerateAge(30, 45),
            Gender = Gender.Male,
        };
        npc.Skills.Add(new Skill(Skills.Blacksmithing, DDRand.Double(0.4, 0.65)));
        npc.Roles.Add(Skills.Blacksmithing);
        npcs.Add(npc);

        return npcs;
    }

    static private int GenerateAge(int min, int max)
    {
        return rnd.Next(min, max);
    }
}