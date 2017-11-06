public class SkillType
{
    public string Name { get; set; }
}

public class Skill
{
    public SkillType SkillType { get; set; }
    public double Proficiency { get; set; }

    public Skill(SkillType skillType, double proficiency)
    {
        SkillType = skillType;
        Proficiency = proficiency;
    }
}

static public class Skills
{
    // Really skill types
    static public SkillType Blacksmithing = new SkillType() { Name = "Blacksmithing" };
    static public SkillType Logging = new SkillType() { Name = "Logging" };
    static public SkillType Mining = new SkillType() { Name = "Mining" };
}