public class ActionProcessor
{
    private readonly ObjectLocator objectLocator;
    private readonly IdsProcessor idsProcessor;

    public ActionProcessor(ObjectLocator objectLocator, IdsProcessor idsProcessor)
    {
        this.objectLocator = objectLocator;
        this.idsProcessor = idsProcessor;
    }

    public Area Area { get; set; }
    public Creature Creature { get; set; }

    public bool NoAction()
    {
        return true;
    }

    public bool ActionOverride(string actor, string action)
    {
        return true;
    }

    public bool AddWayPoint(string waypoint)
    {
        return true;
    }

    public bool Attack(string target)
    {
        return true;
    }

    public bool BackStab(string target)
    {
        return true;
    }

    public bool CreateCreature(string newOject, string location, int face)
    {
        return true;
    }

    public bool Dialog(string @object)
    {
        return true;
    }

    public bool Dialogue(string @object)
    {
        return Dialog(@object);
    }

    public bool DropItem(string @object, string location)
    {
        return true;
    }

    public bool Enemy()
    {
        return true;
    }

    public bool FindTraps()
    {
        return true;
    }

    public bool GetItems(string @object, string target)
    {
        return true;
    }


    public bool JoinParty(string input, int other)
    {
        return true;
    }
}