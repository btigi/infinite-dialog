using ii.InfinityEngine.Files;

public class Party()
{
    public int PartyGold { get; set; }
    public List<PartyMember> Members { get; set; } = [];
}

public class PartyMember
{
    public CreFile Creature { get; set; }
    public int ModalAction { get; set; }
    public int Happiness { get; set; }
    public int State { get; set; }
}