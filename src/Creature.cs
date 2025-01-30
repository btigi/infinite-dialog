public class Creature()
{
    public List<(string variable, string value)> Variables = [];
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Wisdeom { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public int Charisma { get; set; }
    public int Class { get; set; }
    public int Specific { get; set; }
    public int Gender { get; set; }
    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int Alignment { get; set; }
    public int General { get; set; }
    public int Race { get; set; }
    public int XP { get; set; }
    public int Morale { get; set; }
    public int Reputation { get; set; }
    public int State { get; set; }

    public bool FallenRanger { get; set; }
    public bool FallenPaladin { get; set; }

    public List<int> MemorisedSpells { get; set; } = [];
    public List<string> Items { get; set; } = [];
}